using Microsoft.EntityFrameworkCore;
using Prepaid.API.Data;
using Prepaid.API.Domain.DTOs;
using Prepaid.API.Domain.Models;
using Prepaid.API.Services.Interfaces;

namespace Prepaid.API.Services.Implementations
{
    public class CardService(AppDbContext context) : ICardService
    {
        public async Task<GeneralResponse> CreateCard(CreateCardDTO card)
        {
            if (card is null) return new GeneralResponse(false, "Model is Empty");
            var checkNumber = await context.Cards.FirstOrDefaultAsync(x => x.CardNumber == card.CardNumber);
            if (checkNumber != null) return new GeneralResponse(false, "Card Number Registered Already");
            var newCard = await AddToDatabase(new Card()
            {
                Balance = 0,
                CardNumber = card.CardNumber,
                CardType = "Master Card",
                Expires = DateTime.Now.AddYears(2),
                UserId = card.UserId,
            });
            return new GeneralResponse(true, "Card Created Successfully");
        }

        public async Task<ServiceResponse<CardDTO>> GetUserCard(int userId)
        {
            var card = await context.Cards.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
            if (card == null) return ErrorResponse<CardDTO>("User has no card");
            var resultCard = new CardDTO()
            {
                Balance = card.Balance,
                CardNumber = card.CardNumber,
                CardType = card.CardType,
                Expires = card.Expires,
                Owner = card.User.Fullname
            };
            return SuccessResponse(resultCard);

        }

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = context.Add(model!);
            await context.SaveChangesAsync();
            return (T)result.Entity;
        }

        public ServiceResponse<T> SuccessResponse<T>(T data, string message = null)
        {
            return new ServiceResponse<T>
            {
                Message = message ?? "Success",
                Status = true,
                Data = data
            };
        }

        public ServiceResponse<T> ErrorResponse<T>(string message = null)
        {
            return new ServiceResponse<T>
            {
                Message = message ?? "Unsuccessful",
                Status = false,
            };
        }
    }
}

using Prepaid.API.Domain.DTOs;

namespace Prepaid.API.Services.Interfaces
{
    public interface ICardService
    {
        public Task<GeneralResponse> CreateCard(CreateCardDTO card);
        Task<ServiceResponse<CardDTO>> GetUserCard(int userId);
    }
}

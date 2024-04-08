using Microsoft.EntityFrameworkCore;
using Prepaid.API.Data;
using Prepaid.API.Domain.DTOs;
using Prepaid.API.Domain.Models;
using Prepaid.API.Services.Interfaces;

namespace Prepaid.API.Utilities
{
    public static class Seeder
    {
        public static async Task SeederUser(AppDbContext context, IServiceScope scope)
        {
            if (context.Users.Any()) return;
            var userManagement = scope.ServiceProvider.GetRequiredService<IUserAccount>();
            var user = new RegisterDTO()
            {
                Email = "oliverjohnson@gmail.com",
                FullName = "Oliver Johnson",
                Password = "password",
                Phone = "09010010010",
                ClientId = 1
            };
            await userManagement.CreateAsync(user);
            return;
        }

        public static async Task SeedCard(AppDbContext context, IServiceScope scope)
        {
            if (context.Cards.Any()) return;
            var user = await context.Users.FirstOrDefaultAsync();
            if (user == default) return;
            var cardManagement = scope.ServiceProvider.GetRequiredService<ICardService>();
            var card = new CreateCardDTO()
            {
                 CardNumber = "4521 5234 6234 7852",
                 CardType = "Master Card",
                 UserId = user.Id,
            };
            await cardManagement.CreateCard(card);
            return;
        }


    }
}

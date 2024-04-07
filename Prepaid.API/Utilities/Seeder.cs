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
                Email = "yen@gmail.com",
                FullName = "Yen",
                Password = "Password",
                Phone = "09010010010",
                ClientId = 100
            };
            await userManagement.CreateAsync(user);
            return;
        }


    }
}

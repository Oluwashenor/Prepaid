using Prepaid.API.Domain.DTOs;

namespace Prepaid.API.Services.Interfaces
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(RegisterDTO user);
        Task<GeneralResponse> SignInAsync(LoginDTO user);
    }
}

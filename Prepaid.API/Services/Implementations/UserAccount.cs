using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Prepaid.API.Data;
using Prepaid.API.Domain.DTOs;
using Prepaid.API.Domain.Models;
using Prepaid.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prepaid.API.Services.Implementations
{
    public class UserAccount(AppDbContext context, IOptions<JwtSection> jwtConfig) : IUserAccount
    {
        public async Task<GeneralResponse> SignInAsync(LoginDTO user)
        {
            if (user == null) return new GeneralResponse(false, "Model is Empty");
            var appUser = await context.Users.FirstOrDefaultAsync(_ => _.PhoneNumber!.Trim()!.Equals(user.Phone!.Trim()));
            if (appUser is null) return new GeneralResponse(false, "User not found");
            if (appUser.ClientId != user.ClientId) return new GeneralResponse(false, "Invalid Client Id");
            if (!BCrypt.Net.BCrypt.Verify(user.Password, appUser.Password))
                return new GeneralResponse(false, "Email/Password not valid");

            string jwtToken = GenerateToken(appUser, "client");

            var data = new GeneralResponse(true, "Login Successful");
            return data;
        }


        public async Task<GeneralResponse> CreateAsync(RegisterDTO user)
        {
            if (user is null) return new GeneralResponse(false, "Model is Empty");
            var checkEmail = await context.Users.FirstOrDefaultAsync(_ => _.Email!.ToLower()!.Equals(user.Email!.ToLower()));
            if (checkEmail != null) return new GeneralResponse(false, "User registered Already");
            var checkPhone = await context.Users.FirstOrDefaultAsync(_ => _.PhoneNumber!.Trim()!.Equals(user.Phone!.Trim()));
            if (checkPhone != null) return new GeneralResponse(false, "User registered Already");
            // Save User
            var appUser = await AddToDatabase(new User()
            {
                Fullname = user.FullName,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                ClientId = user.ClientId,
                PhoneNumber = user.Phone
            });
            return new GeneralResponse(true, "Account Created");
        }


        private string GenerateToken(User appUser, string? role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim(ClaimTypes.Name, appUser.Fullname!),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Role, role),
            };
            var token = new JwtSecurityToken(
                issuer: jwtConfig.Value.Issuer,
                audience: jwtConfig.Value.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddSeconds(5),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = context.Add(model!);
            await context.SaveChangesAsync();
            return (T)result.Entity;
        }
    }
}

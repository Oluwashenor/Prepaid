using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prepaid.API.Domain.DTOs;
using Prepaid.API.Services.Interfaces;

namespace Prepaid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController(IUserAccount userAccount) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync(LoginDTO user)
        {
            if (user == null) return BadRequest("Model is empty");
            var result = await userAccount.SignInAsync(user);
            return Ok(result);
        }
    }
}

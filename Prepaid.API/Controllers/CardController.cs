using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prepaid.API.Domain.DTOs;
using Prepaid.API.Services.Implementations;
using Prepaid.API.Services.Interfaces;

namespace Prepaid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CardController(ICardService cardService) : ControllerBase
    {
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(ServiceResponse<CardDTO>), 200)]
        public async Task<IActionResult> SignInAsync(int userId)
        {
            if (userId == default) return BadRequest("Model is empty");
            var result = await cardService.GetUserCard(userId);
            return Ok(result);
        }
    }
}

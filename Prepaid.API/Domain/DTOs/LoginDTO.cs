using System.ComponentModel.DataAnnotations;

namespace Prepaid.API.Domain.DTOs
{
    public class LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}

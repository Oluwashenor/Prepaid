using System.ComponentModel.DataAnnotations;

namespace Prepaid.API.Domain.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string? FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}

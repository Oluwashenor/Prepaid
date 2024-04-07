using System.ComponentModel.DataAnnotations;

namespace Prepaid.Client.Domain.APIModels
{
    public class AuthModels
    {
    }

    public class LoginDTO
    {
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        public long ClientId { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Prepaid.API.Domain.DTOs
{
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

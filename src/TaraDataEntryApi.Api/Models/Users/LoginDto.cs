﻿using System.ComponentModel.DataAnnotations;

namespace TARA.DATAENTRY.API.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
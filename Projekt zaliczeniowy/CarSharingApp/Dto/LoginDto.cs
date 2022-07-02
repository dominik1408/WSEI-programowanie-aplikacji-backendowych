﻿using System.ComponentModel.DataAnnotations;

namespace CarSharingApp.Dto
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

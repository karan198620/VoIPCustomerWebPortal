using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VoipProjectEntities.Application.Models.Authentication
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}

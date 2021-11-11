using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VoipProjectEntities.Application.Models.Authentication
{
    public class DeleteRequest
    {
        [Required]
        public string CutomerId { get; set; }
    }
}

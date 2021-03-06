using System;
using System.Collections.Generic;

namespace VoipProjectEntities.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public int CustomerTypeId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }        
    }
}

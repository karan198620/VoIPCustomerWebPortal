using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Models.Authentication
{
    public class GetByIdResponse
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string OrganisationName { get; set; }
        public int CustomerTypeId { get; set; }
        public string Email { get; set; }
    }
}

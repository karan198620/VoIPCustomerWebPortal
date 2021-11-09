using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Customers.Queries.ValidateEmail
{
     public class ValidateEmailListQuery : IRequest<Response<IEnumerable<CustomerListVm>>>
    {
        public string Email { get; set; }
    }
}

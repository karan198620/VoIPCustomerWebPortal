using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerDetailQuery : IRequest<Response<CustomerDetailVm>>
    {
        public string Id { get; set; }
    }
}

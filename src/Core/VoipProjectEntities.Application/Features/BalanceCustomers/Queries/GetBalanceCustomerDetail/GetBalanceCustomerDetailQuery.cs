using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomerDetail
{
    public class GetBalanceCustomerDetailQuery : IRequest<Response<BalanceCustomerDetailVm>>
    {
        public string Id { get; set; }
    }
}

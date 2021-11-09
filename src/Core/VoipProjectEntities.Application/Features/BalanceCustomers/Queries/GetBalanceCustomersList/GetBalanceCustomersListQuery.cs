using VoipProjectEntities.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomersList
{
    public class GetBalanceCustomersListQuery : IRequest<Response<IEnumerable<BalanceCustomerListVm>>>
    {
        

    }
}

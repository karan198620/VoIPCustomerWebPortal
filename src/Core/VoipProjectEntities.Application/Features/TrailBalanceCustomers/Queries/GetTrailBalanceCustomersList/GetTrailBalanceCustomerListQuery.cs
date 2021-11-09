using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VoipProjectEntities.Application.Responses;

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Queries.GetTrialBalanceCustomerList
{
   public class GetTrailBalanceCustomerListQuery : IRequest<Response<IEnumerable<TrailBalanceCustomerListVm>>>
    {
    }
}

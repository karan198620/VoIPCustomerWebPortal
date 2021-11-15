using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerList
{
    public class GetSubscriptionCustomersListQueryHandler : IRequestHandler<GetSubscriptionCustomerListQuery, Response<IEnumerable<SubscriptionCustomersListVm>>>
    {
        private readonly IAsyncRepository<SubscriptionCustomer> _subscriptioncustomerRepository;
        private readonly IMapper _mapper;
        public GetSubscriptionCustomersListQueryHandler(IMapper mapper, IAsyncRepository<SubscriptionCustomer> subscriptioncustomerRepository)
        {
            _mapper = mapper;
            _subscriptioncustomerRepository = subscriptioncustomerRepository;
        }
        public async  Task<Response<IEnumerable<SubscriptionCustomersListVm>>> Handle(GetSubscriptionCustomerListQuery request, CancellationToken cancellationToken)
        {
            var allSubscriptionCustomers = (await _subscriptioncustomerRepository.ListAllAsync()).Where(c=>c.CustomerId==request.Customerid);
            var subscriptioncustomerList = _mapper.Map<List<SubscriptionCustomersListVm>>(allSubscriptionCustomers);
            var response = new Response<IEnumerable<SubscriptionCustomersListVm>>(subscriptioncustomerList);
            return response;
        }
    }
}

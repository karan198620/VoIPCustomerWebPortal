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

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Queries.GetTrialBalanceCustomerList
{
    public class GetTrailBalanceCustomerListQueryHandler : IRequestHandler<GetTrailBalanceCustomerListQuery, Response<IEnumerable<TrailBalanceCustomerListVm>>>
    {
        private readonly IAsyncRepository<TrailBalanceCustomer> _trailBalanceCustomerRepository;
        private readonly IMapper _mapper;

        public GetTrailBalanceCustomerListQueryHandler(IMapper mapper, IAsyncRepository<TrailBalanceCustomer> trailBalanceCustomerRepository)
        {
            _mapper = mapper;
            _trailBalanceCustomerRepository = trailBalanceCustomerRepository;
        }
        public async Task<Response<IEnumerable<TrailBalanceCustomerListVm>>> Handle(GetTrailBalanceCustomerListQuery request, CancellationToken cancellationToken)
        {

            var allTrailBalanceCustomer = (await _trailBalanceCustomerRepository.ListAllAsync()).OrderBy(x => x.TrailBalanceCustomerId);
            var trailBalanceCustomerList = _mapper.Map<List<TrailBalanceCustomerListVm>>(allTrailBalanceCustomer);
            var response = new Response<IEnumerable<TrailBalanceCustomerListVm>>(trailBalanceCustomerList);
            return response;
        }
    }
}

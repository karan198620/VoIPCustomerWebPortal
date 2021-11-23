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

namespace VoipProjectEntities.Application.Features.TrailBalanceCustomers.Queries.GetTrailBalanceCustomersList
{
    public class GetTrailBalanceCustomerListQueryHandler : IRequestHandler<GetTrailBalanceCustomerListQuery, Response<IEnumerable<TrailBalanceCustomerListVm>>>
    {
        private readonly ITrailBalanceCustomerRepository _trailBalanceCustomerRepository;
        private readonly IMapper _mapper;

        public GetTrailBalanceCustomerListQueryHandler(IMapper mapper, ITrailBalanceCustomerRepository trailBalanceCustomerRepository)
        {
            _mapper = mapper;
            _trailBalanceCustomerRepository = trailBalanceCustomerRepository;
        }
        public async Task<Response<IEnumerable<TrailBalanceCustomerListVm>>> Handle(GetTrailBalanceCustomerListQuery request, CancellationToken cancellationToken)
        {
            var allTrailBalanceCustomers = (request.FromDate == null && request.ToDate == null) ? await _trailBalanceCustomerRepository.ListAllAsync() : (await _trailBalanceCustomerRepository.ListAllAsync()).Where(x => x.Date >= Convert.ToDateTime(request.FromDate) && x.Date <= Convert.ToDateTime(request.ToDate));
            var trailBalanceCustomerList = _mapper.Map<List<TrailBalanceCustomerListVm>>(allTrailBalanceCustomers);
            var response = new Response<IEnumerable<TrailBalanceCustomerListVm>>(trailBalanceCustomerList);
            return response;
        }
    }
}

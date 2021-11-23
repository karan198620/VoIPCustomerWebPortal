using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomersList
{
    public class GetBalanceCustomersListQueryHandler : IRequestHandler<GetBalanceCustomersListQuery, Response<IEnumerable<BalanceCustomerListVm>>>
    {
        private readonly IAsyncRepository<BalanceCustomer> _balancecustomerRepository;
        private readonly IMapper _mapper;

        public GetBalanceCustomersListQueryHandler(IMapper mapper, IAsyncRepository<BalanceCustomer> balancecustomerRepository)
        {
            _mapper = mapper;
            _balancecustomerRepository = balancecustomerRepository;
        }

        public async Task<Response<IEnumerable<BalanceCustomerListVm>>> Handle(GetBalanceCustomersListQuery request, CancellationToken cancellationToken)
        {
            var allBalanceCustomers = (await _balancecustomerRepository.ListAllAsync()).Where(c => c.CustomerId == request.Customerid);
            var balancecustomerlist = _mapper.Map<List<BalanceCustomerListVm>>(allBalanceCustomers);
            var response = new Response<IEnumerable<BalanceCustomerListVm>>(balancecustomerlist);
            return response;
        }
    }
}

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

namespace VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, Response<IEnumerable<CustomerListVm>>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<Response<IEnumerable<CustomerListVm>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = (await _customerRepository.ListAllAsync()).OrderBy(x => x.CustomerId);
            var customerList = _mapper.Map<List<CustomerListVm>>(allCustomers);
            var response = new Response<IEnumerable<CustomerListVm>>(customerList);
            return response;
        }
    }
}

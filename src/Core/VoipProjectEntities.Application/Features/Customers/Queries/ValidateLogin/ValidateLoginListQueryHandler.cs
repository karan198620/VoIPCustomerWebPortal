using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Customers.Queries.ValidateLogin
{
    public class ValidateLoginListQueryHandler : IRequestHandler<ValidateLoginListQuery, Response<IEnumerable<CustomerListVm>>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public ValidateLoginListQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<Response<IEnumerable<CustomerListVm>>> Handle(ValidateLoginListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = (await _customerRepository.ListAllAsync()).Where(c=>c.CustomerName == request.Username && c.Password == request.Password).OrderBy(x => x.CustomerId);
            var customerList = _mapper.Map<List<CustomerListVm>>(allCustomers);
            var response = new Response<IEnumerable<CustomerListVm>>(customerList);
            return response;
        }
    }
}

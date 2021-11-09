using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, Response<CustomerDetailVm>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public GetCustomerDetailQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository,  IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Response<CustomerDetailVm>> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            string id = _protector.Unprotect(request.Id);

            var @customer = await _customerRepository.GetByIdAsync(new Guid(id));
            var customerDetailDto = _mapper.Map<CustomerDetailVm>(@customer);
            var response = new Response<CustomerDetailVm>(customerDetailDto);
            return response;
        }
    }
}

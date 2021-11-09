using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomerDetail
{
    public class GetBalanceCustomerDetailQueryHandler : IRequestHandler<GetBalanceCustomerDetailQuery, Response<BalanceCustomerDetailVm>>
    {
        private readonly IAsyncRepository<BalanceCustomer> _balancecustomerRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;


        private readonly IDataProtector _protector;
        public GetBalanceCustomerDetailQueryHandler(IMapper mapper, IAsyncRepository<BalanceCustomer> balancecustomerRepository, IAsyncRepository<Category> categoryRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _balancecustomerRepository = balancecustomerRepository;
            _categoryRepository = categoryRepository;
            _protector = provider.CreateProtector("");
        }


        public async Task<Response<BalanceCustomerDetailVm>> Handle(GetBalanceCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            string id = _protector.Unprotect(request.Id);

            var @event = await _balancecustomerRepository.GetByIdAsync(new Guid(id));
            var balancecustomerDetailDto = _mapper.Map<BalanceCustomerDetailVm>(@event);



            var response = new Response<BalanceCustomerDetailVm>(balancecustomerDetailDto);
            return response;
            //throw new NotImplementedException();
        }
    }
}

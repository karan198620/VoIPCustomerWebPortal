using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerDetail
{
    public class GetSubscriptionCustomerDetailQueryHandler : IRequestHandler<GetSubscriptionCustomerDetailQuery, Response<SubscriptionCustomerDetailVm>>
    {
        private readonly IAsyncRepository<SubscriptionCustomer> _subscriptioncustomerRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetSubscriptionCustomerDetailQueryHandler(IMapper mapper, IAsyncRepository<SubscriptionCustomer> subscriptioncustomerRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _subscriptioncustomerRepository = subscriptioncustomerRepository;
            _protector = provider.CreateProtector("");
        }
        public async  Task<Response<SubscriptionCustomerDetailVm>> Handle(GetSubscriptionCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            string id = _protector.Unprotect(request.Id);

            var @subscriptioncustomer = await _subscriptioncustomerRepository.GetByIdAsync(new Guid(id));
            var subscriptioncustomerDetailDto = _mapper.Map<SubscriptionCustomerDetailVm>(@subscriptioncustomer);
            var response = new Response<SubscriptionCustomerDetailVm>(subscriptioncustomerDetailDto);
            return response;
        }
    }
    }

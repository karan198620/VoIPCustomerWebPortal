using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Models.Mail;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CreateCustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Response<CreateCustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var createMenuCommandResponse = new Response<CreateCustomerDto>();

            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createMenuCommandResponse.Succeeded = false;
                createMenuCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createMenuCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var menu = new Customer() { CreatedAt = request.CreatedAt, UpdatedAt = request.UpdatedAt, CustomerName = request.CustomerName, CustomerTypeID = request.CustomerTypeID, Email = request.Email, ISMigrated = request.ISMigrated, ISTrialBalanceOpted = request.ISTrialBalanceOpted, Password = request.Password };
                menu = await _customerRepository.AddAsync(menu);
                createMenuCommandResponse.Data = _mapper.Map<CreateCustomerDto>(menu);
                createMenuCommandResponse.Succeeded = true;
                createMenuCommandResponse.Message = "success";
            }

            return createMenuCommandResponse;
        }
    }
}

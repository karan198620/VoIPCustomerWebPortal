using AutoMapper;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.UpdateBalanceCustomer
{
    public class UpdateBalanceCustomerCommandHandler : IRequestHandler<UpdateBalanceCustomerCommand, Response<Guid>>
    {
        private readonly IBalanceCustomerRepository _balancecustomerRepository;
        private readonly IMapper _mapper;
        
        public UpdateBalanceCustomerCommandHandler(IMapper mapper, IBalanceCustomerRepository balancecustomerRepository)
        {
            _mapper = mapper;
            _balancecustomerRepository = balancecustomerRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateBalanceCustomerCommand request, CancellationToken cancellationToken)
        {
            var balancecustomerToUpdate = await _balancecustomerRepository.GetByIdAsync(request.BalanceCustomerID);

            if (balancecustomerToUpdate == null)
            {
                throw new NotFoundException(nameof(AgentCustomer), request.BalanceCustomerID);
            }

            var validator = new UpdateBalanceCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, balancecustomerToUpdate, typeof(UpdateBalanceCustomerCommand), typeof(BalanceCustomer));

            await _balancecustomerRepository.UpdateAsync(balancecustomerToUpdate);

            return new Response<Guid>(request.BalanceCustomerID, "Updated successfully ");
            //throw new NotImplementedException();
        }






        //throw new NotImplementedException();
    }


    
}

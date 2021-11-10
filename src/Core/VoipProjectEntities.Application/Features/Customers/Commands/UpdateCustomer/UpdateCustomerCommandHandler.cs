using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Application.Responses;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToUpdate == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            var validator = new UpdateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

            await _customerRepository.UpdateAsync(customerToUpdate);

            return new Response<Guid>(request.Id, "Updated successfully ");
        }
    }
}

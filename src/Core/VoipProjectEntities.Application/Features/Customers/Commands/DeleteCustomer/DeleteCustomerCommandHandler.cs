using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDataProtector _protector;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IDataProtectionProvider provider)
        {
            _customerRepository = customerRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerId = new Guid(_protector.Unprotect(request.Id));
            //var customerId = request.CustomerId;
            var customerToDelete = await _customerRepository.GetByIdAsync(customerId);

            if (customerToDelete == null)
            {
                throw new NotFoundException(nameof(Customer), customerId);
            }
            await _customerRepository.DeleteAsync(customerToDelete);
            return Unit.Value;
        }
    }
}

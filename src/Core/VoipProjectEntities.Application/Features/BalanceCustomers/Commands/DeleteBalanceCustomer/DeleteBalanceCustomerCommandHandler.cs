using VoipProjectEntities.Application.Contracts.Persistence;
using VoipProjectEntities.Application.Exceptions;
using VoipProjectEntities.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VoipProjectEntities.Application.Features.BalanceCustomers.Commands.DeleteBalanceCustomer
{
    public class DeleteBalanceCustomerCommandHandler : IRequestHandler<DeleteBalanceCustomerCommand>
    {
        private readonly IBalanceCustomerRepository _balancecustomerRepository;
        private readonly IDataProtector _protector;


        public DeleteBalanceCustomerCommandHandler(IBalanceCustomerRepository balancecustomerRepository, IDataProtectionProvider provider)
        {
            _balancecustomerRepository = balancecustomerRepository;
            _protector = provider.CreateProtector("");
        }



        public async Task<Unit> Handle(DeleteBalanceCustomerCommand request, CancellationToken cancellationToken)
        {

            var balancecustomerId = new Guid(_protector.Unprotect(request.BalanceCustomerID));
            var balancecustomerToDelete = await _balancecustomerRepository.GetByIdAsync(balancecustomerId);


            if (balancecustomerToDelete == null)
            {
                throw new NotFoundException(nameof(BalanceCustomer), balancecustomerId);
            }

            await _balancecustomerRepository.DeleteAsync(balancecustomerToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}

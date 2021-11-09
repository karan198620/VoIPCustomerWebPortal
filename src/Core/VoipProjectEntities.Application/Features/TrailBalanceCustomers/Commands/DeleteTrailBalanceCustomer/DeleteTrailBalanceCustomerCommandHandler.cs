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

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.DeleteTrialBalanceCustomer
{
    public class DeleteTrailBalanceCustomerCommandHandler : IRequestHandler<DeleteTrailBalanceCustomerCommand>
    {

        private readonly ITrailBalanceCustomerRepository _trailBalanceCustomerRepository;
        private readonly IDataProtector _protector;

        public DeleteTrailBalanceCustomerCommandHandler(ITrailBalanceCustomerRepository trailBalanceCustomerRepository, IDataProtectionProvider provider)
        {
            _trailBalanceCustomerRepository = trailBalanceCustomerRepository;
            _protector = provider.CreateProtector("");

        }

        public async Task<Unit> Handle(DeleteTrailBalanceCustomerCommand request, CancellationToken cancellationToken)
        {
            var trailBalanceCustomerId = new Guid(_protector.Unprotect(request.TrailBalanceCustomerId));
            var trailBalanceCustomerToDelete = await _trailBalanceCustomerRepository.GetByIdAsync(trailBalanceCustomerId);

            if (trailBalanceCustomerToDelete == null)
            {
                throw new NotFoundException(nameof(TrailBalanceCustomer), trailBalanceCustomerId);
            }

            await _trailBalanceCustomerRepository.DeleteAsync(trailBalanceCustomerToDelete);
            return Unit.Value;
        }
    }
}
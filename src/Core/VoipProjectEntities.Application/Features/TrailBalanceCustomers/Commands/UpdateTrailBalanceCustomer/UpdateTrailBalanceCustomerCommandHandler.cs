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

namespace VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.UpdateTrialBalanceCustomer
{
    public class UpdateTrailBalanceCustomerCommandHandler : IRequestHandler<UpdateTrailBalanceCustomerCommand, Response<Guid>>
    {
        private readonly ITrailBalanceCustomerRepository _trailBalanceCustomerRepository;
        private readonly IMapper _mapper;

        public UpdateTrailBalanceCustomerCommandHandler(IMapper mapper, ITrailBalanceCustomerRepository trailBalanceCustomerRepository)
        {
            _mapper = mapper;
            _trailBalanceCustomerRepository = trailBalanceCustomerRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateTrailBalanceCustomerCommand request, CancellationToken cancellationToken)
        {
            var trailBalanceCustomerToUpdate = await _trailBalanceCustomerRepository.GetByIdAsync(request.TrailBalanceCustomerId);

            if (trailBalanceCustomerToUpdate == null)
            {
                throw new NotFoundException(nameof(TrailBalanceCustomer), request.TrailBalanceCustomerId);
            }

            var validator = new UpdateTrailBalanceCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, trailBalanceCustomerToUpdate, typeof(UpdateTrailBalanceCustomerCommand), typeof(TrailBalanceCustomer));

            await _trailBalanceCustomerRepository.UpdateAsync(trailBalanceCustomerToUpdate);

            return new Response<Guid>(request.TrailBalanceCustomerId, "Updated successfully ");
        }
    }
}

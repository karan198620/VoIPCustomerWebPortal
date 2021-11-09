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

namespace VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.DeleteCallRecordingAgent
{
    public class DeleteCallRecordingAgentCommandHandler : IRequestHandler<DeleteCallRecordingAgentCommand>
    {
        private readonly ICallRecordingAgentRepository _callrecordingagentRepository;
        private readonly IDataProtector _protector;


        public DeleteCallRecordingAgentCommandHandler(ICallRecordingAgentRepository callrecordingagentRepository, IDataProtectionProvider provider)
        {
            _callrecordingagentRepository = callrecordingagentRepository;
            _protector = provider.CreateProtector("");
        }



        public async Task<Unit> Handle(DeleteCallRecordingAgentCommand request, CancellationToken cancellationToken)
        {

            var  callrecordingagentId = new Guid(_protector.Unprotect(request.CallRecordingAgentID));
            var callrecordingagentToDelete = await _callrecordingagentRepository.GetByIdAsync(callrecordingagentId);


            if (callrecordingagentToDelete == null)
            {
                throw new NotFoundException(nameof(CallRecordingAgent), callrecordingagentId);
            }

            await _callrecordingagentRepository.DeleteAsync(callrecordingagentToDelete);
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}

using VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.CreateCallRecordingAgent;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.DeleteCallRecordingAgent;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.UpdateCallRecordingAgent;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCalllRecordingAgentDetail;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCallRecordingAgentsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallRecordingAgentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CallRecordingAgentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //get alllist
        [HttpGet(Name = "GetAllCallRecordingAgent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllEvents()
        {
            var dtos = await _mediator.Send(new GetCallRecordingAgentsListQuery());
            return Ok(dtos);
        }

        //get by id

        [HttpGet("{id}", Name = "GetCallRecordingAgentById")]
        public async Task<ActionResult> GetEventById(string id)
        {
            var getCallRecordingAgentDetailQuery = new GetCallRecordingAgentDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getCallRecordingAgentDetailQuery));
        }



        [HttpPost(Name = "AddCallRecordingAgent")]
        public async Task<ActionResult> Create([FromBody] CreateCallRecordingAgentCommand createCallRecordingAgentCommand)
        {
            var id = await _mediator.Send(createCallRecordingAgentCommand);
            return Ok(id);
        }

        [HttpDelete("{id}", Name = "DeleteCallRecordingAgent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteAgentCustomerCommand = new DeleteCallRecordingAgentCommand() { CallRecordingAgentID = id };
            await _mediator.Send(deleteAgentCustomerCommand);
            return NoContent();
        }

        [HttpPut(Name = "UpdateCallRecordingAgent")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCallRecordingAgentCommand updateCallRecordingAgentCommand)
        {
            var response = await _mediator.Send(updateCallRecordingAgentCommand);
            return Ok(response);
        }
    }
}

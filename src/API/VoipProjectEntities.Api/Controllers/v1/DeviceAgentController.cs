using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.DeviceAgents.Commands.CreateDeviceAgent;
using VoipProjectEntities.Application.Features.DeviceAgents.Commands.DeleteDeviceAgent;
using VoipProjectEntities.Application.Features.DeviceAgents.Commands.UpdateDeviceAgent;
using VoipProjectEntities.Application.Features.DeviceAgents.Queries.GetDeviceAgentList;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceAgentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceAgentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllDeviceAgents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllDeviceAgents()
        {
            var dtos = await _mediator.Send(new GetDeviceAgentListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddDeviceAgent")]
        public async Task<ActionResult> Create([FromBody] CreateDeviceAgentCommand createDeviceAgentCommand)
        {
            var id = await _mediator.Send(createDeviceAgentCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateDeviceAgent")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateDeviceAgentCommand updateDeviceAgentCommand)
        {
            var response = await _mediator.Send(updateDeviceAgentCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteDeviceAgent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteDeviceAgentCommand = new DeleteDeviceAgentCommand() { DeviceAgentId = id };
            await _mediator.Send(deleteDeviceAgentCommand);
            return NoContent();
        }

    }
}

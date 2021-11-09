using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomersList;
using VoipProjectEntities.Application.Features.AgentCustomers.Commands.DeleteAgentCustomer;
using VoipProjectEntities.Application.Features.AgentCustomers.Commands.CreateAgentCustomer;
using VoipProjectEntities.Application.Features.AgentCustomers.Commands.UpdateAgentCustomer;
using VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomerDetail;

namespace VoipMainProject.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgentCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Method To get allagent Customer
        [HttpGet(Name = "GetAllAgentCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllEvents()
        {
            var dtos = await _mediator.Send(new GetAgentCustomersListQuery());
            return Ok(dtos);
        }


        //method to del agentcontroller bu Id

        [HttpDelete("{id}", Name = "DeleteAgentCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteAgentCustomerCommand = new DeleteAgentCustomerCommand() { AgentCustomerID = id };
            await _mediator.Send(deleteAgentCustomerCommand);
            return NoContent();
        }


        //method to add agent customer / Create agentCustomer

        [HttpPost(Name = "AddAgentCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateAgentCustomerCommand createAgentCustomerCommand)
        {
            var id = await _mediator.Send(createAgentCustomerCommand);
            return Ok(id);
        }

        //method  to update agent customer

        [HttpPut(Name = "UpdateAgentCustomer")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAgentCustomerCommand updateAgentCustomerCommand)
        {
            var response = await _mediator.Send(updateAgentCustomerCommand);
            return Ok(response);
        }

        //method to get agentcustomer By ID
        [HttpGet("{id}", Name = "GetAgentCustomerById")]
        public async Task<ActionResult> GetEventById(string id)
        {
            var getAgentCustomerDetailQuery = new GetAgentCustomerDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getAgentCustomerDetailQuery));
        }
    }
}

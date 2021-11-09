using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.CreateTrialBalanceCustomer;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.DeleteTrialBalanceCustomer;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.UpdateTrialBalanceCustomer;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Queries.GetTrialBalanceCustomerList;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailBalanceCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrailBalanceCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "TrailBalanceCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetTrailBalanceCustomers()
        {
            var dtos = await _mediator.Send(new GetTrailBalanceCustomerListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddTrailBalanceCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateTrailBalanceCustomerCommand createTrailBalanceCustomerCommand)
        {
            var id = await _mediator.Send(createTrailBalanceCustomerCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateTrailBalanceCustomer")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTrailBalanceCustomerCommand updateTrailBalanceCustomerCommand)
        {
            var response = await _mediator.Send(updateTrailBalanceCustomerCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "TrailBalanceCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteMenuAccessCommand = new DeleteTrailBalanceCustomerCommand() { TrailBalanceCustomerId = id };
            await _mediator.Send(deleteMenuAccessCommand);
            return NoContent();
        }
    }
}

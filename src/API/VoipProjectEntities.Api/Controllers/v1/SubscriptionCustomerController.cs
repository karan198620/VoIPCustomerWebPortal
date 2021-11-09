using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.CreateSubscriptionCustomer;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.DeleteSubscriptionCustomer;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.UpdateSubscriptionCustomer;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerDetail;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerList;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubscriptionCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllSubscriptionCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllSetting()
        {
            var dtos = await _mediator.Send(new GetSubscriptionCustomerListQuery());
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetSubscriptionCustomerById")]
        public async Task<ActionResult> GetCustomerById(string id)
        {
            var getSubscriptionCustomerDetailQuery = new GetSubscriptionCustomerDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getSubscriptionCustomerDetailQuery));
        }

        [HttpPost(Name = "AddSubscriptionCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateSubscriptionCustomerCommand createSubscriptionCustomerCommand)
        {
            var id = await _mediator.Send(createSubscriptionCustomerCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateSubscriptionCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSubscriptionCustomerCommand updatesubscriptioncustomerCommand)
        {
            var response = await _mediator.Send(updatesubscriptioncustomerCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteSubscriptionCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteSubscriptionCustomerCommand = new DeleteSubscriptionCustomerCommand() { SubscriptionCustomerID = id };
            await _mediator.Send(deleteSubscriptionCustomerCommand);
            return NoContent();
        }
    }
}

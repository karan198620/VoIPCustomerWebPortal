using VoipProjectEntities.Application.Features.BalanceCustomers.Commands.DeleteBalanceCustomer;
using VoipProjectEntities.Application.Features.BalanceCustomers.Commands.UpdateBalanceCustomer;
using VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomerDetail;
using VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomersList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.BalanceCustomers.Commands.CreateBalanceCustomer;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BalanceCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost(Name = "AddBalanceCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateBalanceCustomerCommand createBalanceCustomerCommand)
        {
            var id = await _mediator.Send(createBalanceCustomerCommand);
            return Ok(id);
        }


        // Method To get allbalance Customer by Customer ID(FK)
        [HttpGet("{id}",Name = "GetAllBalanceCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllEvents(string id)
        {
            var dtos = await _mediator.Send(new GetBalanceCustomersListQuery() {Customerid = id });
            return Ok(dtos);
        }

        //method to get balancecustomer By ID
        [HttpGet("GetBalanceCustomerById/{id}")]
        public async Task<ActionResult> GetEventById(string id)
        {
            var getBalanceCustomerDetailQuery = new GetBalanceCustomerDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getBalanceCustomerDetailQuery));
        }


        //method  to update balance customer

        [HttpPut(Name = "UpdateBalanceCustomer")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBalanceCustomerCommand updateBalanceCustomerCommand)
        {
            var response = await _mediator.Send(updateBalanceCustomerCommand);
            return Ok(response);
        }

        //method to del balancecustomer bu Id

        [HttpDelete("{id}", Name = "DeleteBalanceCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteBalanceCustomerCommand = new DeleteBalanceCustomerCommand() { BalanceCustomerID = id };
            await _mediator.Send(deleteBalanceCustomerCommand);
            return NoContent();
        }
    }
}

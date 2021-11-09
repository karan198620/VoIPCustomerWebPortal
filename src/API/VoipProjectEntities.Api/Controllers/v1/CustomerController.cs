using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.Customers.Commands.CreateCustomer;
using VoipProjectEntities.Application.Features.Customers.Commands.DeleteCustomer;
using VoipProjectEntities.Application.Features.Customers.Commands.UpdateCustomer;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerById;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList;
using VoipProjectEntities.Application.Features.Customers.Queries.ValidateLogin;
using VoipProjectEntities.Application.Features.Customers.Queries.ValidateEmail;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomerListQuery());
            return Ok(dtos);
        }

        [HttpGet("ValidateLogin/{username}/{password}", Name = "ValidateLogin")]
        public async Task<ActionResult> ValidateLogin(string username, string password)
        {
            var validateCustomerListQuery = new ValidateLoginListQuery() { Username = username, Password = password };
            var dtos = await _mediator.Send(validateCustomerListQuery);
            return Ok(dtos);
        }

        [HttpGet("ValidateEmail/{email}", Name = "ValidateEmail")]
        public async Task<ActionResult> ValidateEmail(string email)
        {
            var validateEmailListQuery = new ValidateEmailListQuery() { Email = email };
            var dtos = await _mediator.Send(validateEmailListQuery);
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult> GetCustomerById(string id)
        {
            var getCustomerDetailQuery = new GetCustomerDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getCustomerDetailQuery));
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var id = await _mediator.Send(createCustomerCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var response = await _mediator.Send(updateCustomerCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { CustomerId = id };
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }        
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu;
using VoipProjectEntities.Application.Features.Menu.Queries.GetMenu;
using VoipProjectEntities.Application.Features.MenuAccesses.Command.DeleteMenuAccess;
using VoipProjectEntities.Application.Features.MenuAccesses.Commands.UpdateMenuAccess;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public MenuController(IMediator mediator, ILogger<MenuController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddMenu")]
        public async Task<ActionResult> Create([FromBody] CreateMenuCommand createMenuCommand)
        {
            var response = await _mediator.Send(createMenuCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("all/{CustomerId}/{IsAccess}", Name = "GetAllMenu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllMenu(string CustomerId, bool IsAccess)
        {
            var dtos = await _mediator.Send(new GetMenuListQuery() { CustomerId = CustomerId, IsAccess = IsAccess});
            return Ok(dtos);
        }

        [HttpPut(Name = "UpdateMenu")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateMenuCommand updateMenuCommand)
        {
            var response = await _mediator.Send(updateMenuCommand);
            return Ok(response);
        }


        [HttpDelete("{id}", Name = "DeleteMenu")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteMenuAccessCommand = new DeleteMenuCommand() { MenuAccessId = id };
            await _mediator.Send(deleteMenuAccessCommand);
            return NoContent();
        }
    }
}

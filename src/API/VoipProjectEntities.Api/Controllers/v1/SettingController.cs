using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoipProjectEntities.Application.Features.Settings.Commands.CreateSetting;
using VoipProjectEntities.Application.Features.Settings.Commands.DeleteSetting;
using VoipProjectEntities.Application.Features.Settings.Commands.UpdateSetting;
using VoipProjectEntities.Application.Features.Settings.Queries.GetSettingDetail;
using VoipProjectEntities.Application.Features.Settings.Queries.GetSettingsList;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SettingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllSetting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllSetting()
        {
            var dtos = await _mediator.Send(new GetSettingsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetSettingById")]
        public async Task<ActionResult> GetCustomerById(string id)
        {
            var getSettingDetailQuery = new GetSettingDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getSettingDetailQuery));
        }

        [HttpPost(Name = "AddSetting")]
        public async Task<ActionResult> Create([FromBody] CreateSettingCommand createSettingCommand)
        {
            var id = await _mediator.Send(createSettingCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateSetting")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSettingCommand updateSettingCommand)
        {
            var response = await _mediator.Send(updateSettingCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteSetting")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteSettingCommand = new DeleteSettingCommand() { SettingID = id };
            await _mediator.Send(deleteSettingCommand);
            return NoContent();
        }
    }
}

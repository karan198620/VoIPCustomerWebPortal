using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoipProjectEntities.Api.Utility;
using VoipProjectEntities.Application.Features.Events.Commands.CreateEvent;
using VoipProjectEntities.Application.Features.Events.Commands.DeleteEvent;
using VoipProjectEntities.Application.Features.Events.Commands.UpdateEvent;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventDetail;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventsExport;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventsList;

namespace VoipProjectEntities.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EventsController : Controller
    {
        private readonly IMediator _mediator;

        private EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        private async Task<ActionResult> GetAllEvents()
        {
            var dtos = await _mediator.Send(new GetEventsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        private async Task<ActionResult> GetEventById(string id)
        {
            var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddEvent")]
        private async Task<ActionResult> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        private async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            var response = await _mediator.Send(updateEventCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        private async Task<ActionResult> Delete(string id)
        {
            var deleteEventCommand = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        private async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }
    }
}

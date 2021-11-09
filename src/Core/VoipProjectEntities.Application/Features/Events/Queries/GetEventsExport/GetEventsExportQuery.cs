using MediatR;

namespace VoipProjectEntities.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery : IRequest<EventExportFileVm>
    {
    }
}

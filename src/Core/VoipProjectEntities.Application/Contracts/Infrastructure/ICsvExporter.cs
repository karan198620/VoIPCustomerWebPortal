using System.Collections.Generic;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventsExport;

namespace VoipProjectEntities.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}

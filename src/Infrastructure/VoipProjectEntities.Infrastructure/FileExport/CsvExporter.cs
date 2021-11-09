using CsvHelper;
using System.Collections.Generic;
using System.IO;
using VoipProjectEntities.Application.Contracts.Infrastructure;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventsExport;

namespace VoipProjectEntities.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}

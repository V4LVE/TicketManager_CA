using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Features.Events.Queries.GetEventsExport;

namespace TicketManager.Management.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        /// <summary>
        /// Export all event data to a CSV file
        /// </summary>
        /// <param name="eventListExportDtos"></param>
        /// <returns></returns>
        byte[] ExportEventsToCsv(List<EventExportDto> eventListExportDtos);
    }
}

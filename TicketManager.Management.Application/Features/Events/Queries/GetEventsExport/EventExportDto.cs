using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Management.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

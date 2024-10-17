using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Domain.Common;

namespace TicketManager.Management.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public List<Event>? Events { get; set; }
    }
}

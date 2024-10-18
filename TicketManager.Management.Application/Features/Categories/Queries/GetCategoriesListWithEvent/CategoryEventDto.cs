using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesListWithEvent
{
    public class CategoryEventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}

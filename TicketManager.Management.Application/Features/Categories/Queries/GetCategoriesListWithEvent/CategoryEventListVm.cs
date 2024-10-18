using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesListWithEvent
{
    public class CategoryEventListVm
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public List<CategoryEventDto>? Events { get; set; }
    }
}

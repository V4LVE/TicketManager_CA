using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncBaseRepository<Category>
    {
        /// <summary>
        /// Gets all categories with an options to include events that have already passed.
        /// </summary>
        /// <param name="includePassedEvents"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}

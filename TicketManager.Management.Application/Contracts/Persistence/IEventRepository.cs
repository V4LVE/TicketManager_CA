using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncBaseRepository<Event>
    {
        /// <summary>
        /// Checks whether an event with the given name and date is unique.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="eventDate"></param>
        /// <returns>a boolean true if its Unique</returns>
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Persistence.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(TicketManagerDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            bool matches = await _dbContext.Events.AnyAsync(e => e.Name == name && e.Date.Date == eventDate.Date);
            return matches;
        }
    }
}

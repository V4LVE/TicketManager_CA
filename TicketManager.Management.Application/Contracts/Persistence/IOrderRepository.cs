using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncBaseRepository<Order>
    {
    }
}

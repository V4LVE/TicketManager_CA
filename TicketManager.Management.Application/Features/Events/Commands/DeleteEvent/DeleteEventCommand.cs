using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Management.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int EventId { get; set; }
    }
}

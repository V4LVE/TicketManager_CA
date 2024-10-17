using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }


        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event mappedEvent = _mapper.Map<Event>(request);
            
            mappedEvent = await _eventRepository.AddAsync(mappedEvent);

            return mappedEvent.EventId;
        }
    }
}

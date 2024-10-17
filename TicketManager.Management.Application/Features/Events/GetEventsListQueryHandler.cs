using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Features.Events
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IAsyncBaseRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncBaseRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }


        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            IOrderedEnumerable<Event> allEvent = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);

            return _mapper.Map<List<EventListVm>>(allEvent);
        }
    }
}

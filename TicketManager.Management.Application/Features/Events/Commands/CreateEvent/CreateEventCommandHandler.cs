using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Application.Exeptions;
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

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validatorResult = await validator.ValidateAsync(request);


            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);


            mappedEvent = await _eventRepository.AddAsync(mappedEvent);




            return mappedEvent.EventId;
        }
    }
}

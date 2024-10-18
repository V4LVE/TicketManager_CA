using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Infrastructure;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Application.Exeptions;
using TicketManager.Management.Application.Models.Mail;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }


        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event mappedEvent = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validatorResult = await validator.ValidateAsync(request);


            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);


            mappedEvent = await _eventRepository.AddAsync(mappedEvent);

            await SendAdminEmail(request);


            return mappedEvent.EventId;
        }

        public async Task SendAdminEmail(CreateEventCommand request)
        {
            var email = new Email()
            {
                To = "test@test.test",
                Body = $"A new event was created {request}",
                Subject = "A new event was created"
            };

            try
            {
                await _emailService.SendMail(email);
            }
            catch (Exception ex)
            {
                // Logging ex 
                
            }
        }
    }
}

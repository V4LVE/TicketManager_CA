using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.Management.Api.Utility;
using TicketManager.Management.Application.Features.Events.Commands.CreateEvent;
using TicketManager.Management.Application.Features.Events.Commands.DeleteEvent;
using TicketManager.Management.Application.Features.Events.Commands.UpdateEvent;
using TicketManager.Management.Application.Features.Events.Queries.GetEventDetail;
using TicketManager.Management.Application.Features.Events.Queries.GetEventsExport;
using TicketManager.Management.Application.Features.Events.Queries.GetEventsList;

namespace TicketManager.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all",Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var result = await _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }


        [HttpGet("getbyid/{id}", Name = "GetEventById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetEventById(int id)
        {
            var result = await _mediator.Send(new GetEventDetailQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost("add",Name = "AddEvent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return CreatedAtRoute("GetEventById", new { id }, id);
        }


        [HttpPut("update",Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var delete = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(delete);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDTO = await _mediator.Send(new GetEventsExportQuery());

            return File(fileDTO.Data, fileDTO.ContentType, fileDTO.EventExportFileName);
        }

    }
        
    
    
}

using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TicketManager.Management.Application.Features.Categories.Commands.CreateCategory;
using TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

namespace TicketManager.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var dtos = await _mediator.Send(new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory });
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Created(HttpContext.Request.GetEncodedPathAndQuery(),response);
        }
    }
}

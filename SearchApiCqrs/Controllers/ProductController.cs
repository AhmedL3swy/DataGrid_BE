using DataGrid.Application.Features.Products.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SearchProductViewModel>>> Search()
        {
            var result = await _mediator.Send(new SearchProductQuery());
            return Ok(result);
        }
    }
}

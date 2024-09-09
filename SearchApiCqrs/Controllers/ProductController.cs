using DataGrid.Application.Features.Products.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataGrid.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<List<SearchProductViewModel>>> Search(SearchProductQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}

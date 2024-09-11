using DataGrid.Application.Features.Search.SearchRequestModels;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using MediatR;
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
        public async Task<IActionResult> Search(SearchQuery<Product, SearchProduct> query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }

}

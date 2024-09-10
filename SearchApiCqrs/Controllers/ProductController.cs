using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

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
        public async Task<IActionResult> Search(SearchQuery<SearchProductViewModel> query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }

}

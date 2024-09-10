using DataGrid.Application.Features.Products.Queries.Search;
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
        public async Task<ActionResult<List<SearchProductViewModel>>> Search(SearchProductQuery query)
        {


            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        // Convert Object to StrongStyped

        // Convert the object to a strongly typed object
        [HttpPost]
        public async Task<ActionResult<SearchProductViewModel>> SearchStrongTyped([FromBody] JsonElement query)
        {
            return Ok(query.ConvertToType<SearchProductViewModel>());
        }


    }
    public static class ObjectExtensions
    {
        public static T ConvertToType<T>(this JsonElement jsonElement)
        {
            // Convert JsonElement to a JSON string
            var jsonString = jsonElement.GetRawText();

            // Deserialize JSON string to the desired type
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }

}

using AutoMapper;
using DataGrid.Application.Features.Search.SearchRequestModels.Product;
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
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Search(SearchQuery<Product, SearchProduct> query)
        {
            var searchResult = await _mediator.Send(query);
            var searchResultDto = new SearchResult<SearchProductResultDto>
            {
                Data = _mapper.Map<List<SearchProductResultDto>>(searchResult.Data),
                Total = searchResult.Total
            };

            return Ok(searchResultDto);

        }
    }

}

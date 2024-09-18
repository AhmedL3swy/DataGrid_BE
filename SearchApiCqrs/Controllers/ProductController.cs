using AutoMapper;
using DataGrid.Application.Contracts;
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
        private readonly ISearchRepositoryV2<Product> _searchRepository;


        public ProductController(IMediator mediator, IMapper mapper, ISearchRepositoryV2<Product> searchRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _searchRepository = searchRepository;
        }


        //[HttpPost]
        //public async Task<IActionResult> Search(SearchQuery<Product, SearchProduct> query)
        //{
        //    var searchResult = await _mediator.Send(query);
        //    var searchResultDto = new SearchResult<SearchProductResultDto>
        //    {
        //        Data = _mapper.Map<List<SearchProductResultDto>>(searchResult.Data),
        //        Total = searchResult.Total
        //    };

        //    return Ok(searchResultDto);

        //}

        [HttpPost]
        public async Task<IActionResult> SearchV2(SearchQueryV2 query) // All is Exposed to Front End
        {
            var searchResult = await _searchRepository.SearchAsync(query);
            return Ok(searchResult);

        }
        [HttpPost]
        public async Task<IActionResult> SearchV3(ProductSearchDTO query)
        {
            query.Include = "Category";
            var searchResult = await _searchRepository.SearchAsync(query);
            var searchResultDto = new SearchResult<SearchProductResultDto>
            {
                Data = _mapper.Map<List<SearchProductResultDto>>(searchResult.Data),
                Total = searchResult.Total
            };
            return Ok(searchResultDto);
        }
    }

}

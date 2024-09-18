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
        //public async Task<IActionResult> Search(SearchQuery<Product, SearchProduct> query) // Removed as it require So much Headache in Dependancy Injection for generic handelers
        //{
        //    var searchResult = await _mediator.Send(query);
        //    var searchResultDto = new SearchResult<SearchProductResultDto>
        //    {
        //        Data = _mapper.Map<List<SearchProductResultDto>>(searchResult.Data),
        //        Total = searchResult.Total
        //    };

        //    return Ok(searchResultDto);

        //}

        /// <summary>
        /// Searches for products using the General query.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>The search result.</returns>
        [HttpPost]
        public async Task<IActionResult> SearchV2(SearchQueryV2 query) // General Search All Model Search will be  Exposed to Front End
        {
            var searchResult = await _searchRepository.SearchAsync(query);
            return Ok(searchResult);
        }

        /// <summary>
        /// Searches for products using the specified query.
        /// </summary>
        /// <param name="query">The product search query.</param>
        /// <returns>The search result.</returns>
        [HttpPost]
        public async Task<IActionResult> SearchV3(ProductSearchDTO query) // Encabsulated SearchQueryV2 Props will be Json Ignored if we will use it this way
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

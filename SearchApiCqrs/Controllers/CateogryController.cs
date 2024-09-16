using AutoMapper;
using DataGrid.Application.Contracts;
using DataGrid.Application.Features.Search.SearchRequestModels.Product;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataGrid.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CateogryController : ControllerBase
    {
        private readonly ISearchRepositoryV2<Category> _searchRepository;
        public CateogryController(ISearchRepositoryV2<Category> searchRepository)
        {
            _searchRepository = searchRepository;
        }



        [HttpPost]
        public async Task<IActionResult> Search(SearchQueryV2 query)
        {
            var searchResult = await _searchRepository.SearchAsync(query);
            return Ok(searchResult);

        }
    }
}

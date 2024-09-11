//using AutoMapper;
//using DataGrid.Application.Features.Search.SearchRequestModels.Product;
//using DataGrid.Application.Shared.Models;
//using DataGrid.Domain;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DataGrid.Api.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class CateogryController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        private readonly IMapper _mapper;

//        public CateogryController(IMediator mediator, IMapper mapper)
//        {
//            _mediator = mediator;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Search(SearchQuery<Category, SearchProduct> query)
//        {

//        }
//    }
//}

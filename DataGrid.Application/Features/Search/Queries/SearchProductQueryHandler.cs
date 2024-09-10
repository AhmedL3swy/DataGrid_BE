using AutoMapper;
using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Search.Queries
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, ApiResult<SearchProductViewModel>>
    {
        private readonly ISearchRepository<Product> _searchRepository;
        private readonly IMapper _mapper;

        public SearchProductQueryHandler(ISearchRepository<Product> searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }
        public async Task<ApiResult<SearchProductViewModel>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _searchRepository.SearchAsync(request);
            var count = products.Count();
            var searchProductViewModel = _mapper.Map<List<SearchProductViewModel>>(products);
            var apiResult = new ApiResult<SearchProductViewModel>
            {
                Data = searchProductViewModel,
                Total = count,
                PageIndex= request.PageNumber,
                PageSize=request.PageSize
            };

            return apiResult;
        }


    }
}

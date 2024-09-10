using AutoMapper;
using DataGrid.Application.Contracts;
using DataGrid.Application.Shared;
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
    public class SearchQueryHandler: IRequestHandler<SearchQuery<SearchProductViewModel>, ApiResult<SearchProductViewModel>>
    {
        private readonly ISearchRepository<Product, SearchProductViewModel> _searchRepository;
        private readonly IMapper _mapper;

        public SearchQueryHandler(ISearchRepository<Product, SearchProductViewModel> searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }
        public async Task<ApiResult<SearchProductViewModel>> Handle(SearchQuery<SearchProductViewModel> request, CancellationToken cancellationToken)
        {
            var products = await _searchRepository.SearchAsync(request);
            var count = products.Count();
            var searchProductViewModel = _mapper.Map<List<SearchProductViewModel>>(products);
            var apiResult = new ApiResult<SearchProductViewModel>
            {
                Data = searchProductViewModel,
                Total = count,
            };

            return apiResult;
        }


    }
}

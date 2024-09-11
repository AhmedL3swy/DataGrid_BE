using AutoMapper;
using DataGrid.Application.Contracts;
using DataGrid.Application.Shared;
using DataGrid.Application.Shared.Models;
using MediatR;

namespace DataGrid.Application.Features.Search.Queries
{
    public class SearchQueryHandler<T, S> : IRequestHandler<SearchQuery<S>, ApiResult<S>> where T : class where S : class
    {
        private readonly ISearchRepository<T, S> _searchRepository;
        private readonly IMapper _mapper;

        public SearchQueryHandler(ISearchRepository<T, S> searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }
        public async Task<ApiResult<S>> Handle(SearchQuery<S> request, CancellationToken cancellationToken)
        {
            var products = await _searchRepository.SearchAsync(request);
            var count = products.Count();
            var searchProductViewModel = _mapper.Map<List<S>>(products);
            var apiResult = new ApiResult<S>
            {
                Data = searchProductViewModel,
                Total = count,
            };

            return apiResult;
        }


    }
}

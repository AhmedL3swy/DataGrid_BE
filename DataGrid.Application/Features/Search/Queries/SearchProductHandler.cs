using AutoMapper;
using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using MediatR;

namespace DataGrid.Application.Features.Search.Queries
{
    public class SearchQueryHandler<DbSet, SearchObject> : IRequestHandler<SearchQuery<DbSet, SearchObject>, SearchResult<DbSet>> where DbSet : class where SearchObject : class
    {
        private readonly ISearchRepository<DbSet, SearchObject> _searchRepository;
        private readonly IMapper _mapper;

        public SearchQueryHandler(ISearchRepository<DbSet, SearchObject> searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }
        public async Task<SearchResult<DbSet>> Handle(SearchQuery<DbSet, SearchObject> request, CancellationToken cancellationToken)
        {
            var products = await _searchRepository.SearchAsync(request);

            return products;
        }


    }
}

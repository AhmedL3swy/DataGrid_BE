using AutoMapper;
using DataGrid.Application.Contracts;
using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using MediatR;

public class SearchQueryHandler<T> : IRequestHandler<SearchProductQuery<T>, ApiResult<T>>
    where T : class
{
    private readonly ISearchRepository<T> _searchRepository;
    private readonly IMapper _mapper;

    public SearchQueryHandler(ISearchRepository<T> searchRepository, IMapper mapper)
    {
        _searchRepository = searchRepository;
        _mapper = mapper;
    }

    public async Task<ApiResult<T>> Handle(SearchProductQuery<T> request, CancellationToken cancellationToken)
    {
        // Fetch items from the repository
        var items = await _searchRepository.SearchAsync(request);

        // Map entities to view models
        var mappedItems = _mapper.Map<List<T>>(items);

        // Create and return ApiResult
        var apiResult = new ApiResult<T>
        {
            Data = mappedItems,
            Total = mappedItems.Count, // Assuming the count is the same for mapped items
            PageIndex = request.PageNumber,
            PageSize = request.PageSize
        };

        return apiResult;
    }
}

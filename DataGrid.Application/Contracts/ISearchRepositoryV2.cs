using DataGrid.Application.Shared.Models;

namespace DataGrid.Application.Contracts
{
    public interface ISearchRepositoryV2<DbSet> where DbSet : class
    {
        Task<SearchResult<DbSet>> SearchAsync(SearchQueryV2 query);
    }
}

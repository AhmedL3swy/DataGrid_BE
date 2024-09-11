using DataGrid.Application.Shared.Models;

namespace DataGrid.Application.Contracts
{
    public interface ISearchRepository<T, S> where T : class where S : class
    {
        Task<List<T>> SearchAsync(SearchQuery<S> query);
    }
}

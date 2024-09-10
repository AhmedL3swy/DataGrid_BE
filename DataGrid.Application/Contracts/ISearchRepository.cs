using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Contracts
{
    public interface ISearchRepository<T, S> where T : class where S : class
    {
        Task<List<T>> SearchAsync(SearchQuery<S> query);
    }
}

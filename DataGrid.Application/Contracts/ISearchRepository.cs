using DataGrid.Application.Features.Search.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Contracts
{
    public interface ISearchRepository<T> where T : class
    {
        Task<List<T>> SearchAsync(SearchProductQuery<T> query);
    }

}

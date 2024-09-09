using DataGrid.Application.Features.Products.Queries.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Contracts
{
    public interface ISearchRepository<T> where T : class
    {
        Task<List<T>> SearchAsync(SearchProductQuery query);
    }
}

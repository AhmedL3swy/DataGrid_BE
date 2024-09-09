using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Products.Queries.Search
{
    public class SearchProductQuery : IRequest<List<SearchProductViewModel>>
    {
        public Dictionary<string, object>? Search { get; set; }
        public Dictionary<string, SortDirection>? Sort { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }

}

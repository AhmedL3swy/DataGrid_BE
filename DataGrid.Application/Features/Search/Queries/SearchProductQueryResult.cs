using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Search.Queries
{
    public class SearchProductQueryResult
    {
        public List<SearchProductViewModel> Data { get; set; }
        public int Total { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}

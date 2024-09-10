using DataGrid.Application.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Search.Queries
{
    public class SearchProductQuery : IRequest<ApiResult<SearchProductViewModel>>
    {
        public SearchProductViewModel Search { get; set; }
        public SortObject Sort { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }

}

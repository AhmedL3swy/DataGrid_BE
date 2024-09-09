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
        public string? SearchValue { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public SearchProductQuery(string? searchValue, string? sortBy, SortDirection sortDirection, int pageNumber, int pageSize)
        {
            SearchValue = searchValue;
            SortBy = sortBy;
            SortDirection = sortDirection;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

}

using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Shared
{
    public class SearchQuery<T> : IRequest<ApiResult<T>> where T : class
    {
        private string sortBy = "Id";
        public T Search { get; set; }
        public string SortBy
        {
            get => sortBy;
            set => sortBy = value.Replace(value[0], char.ToUpper(value[0]));
        }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }

}

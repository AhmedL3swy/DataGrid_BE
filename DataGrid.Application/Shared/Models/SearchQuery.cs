using DataGrid.Application.Shared.Models;
using MediatR;

namespace DataGrid.Application.Shared.Models
{
    public class SearchQuery<S> : IRequest<ApiResult<S>> where S : class
    {
        public S Search { get; set; }

        private string sortBy = null;

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

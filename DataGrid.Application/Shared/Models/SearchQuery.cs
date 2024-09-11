using MediatR;

namespace DataGrid.Application.Shared.Models
{
    public class SearchQuery<DbSet, SearchObject> : IRequest<SearchResult<DbSet>> where SearchObject : class where DbSet : class
    {
        public SearchObject Search { get; set; }

        private string sortBy = null;

        public string SortBy
        {
            get => sortBy;
            set => sortBy = value.Replace(value[0], char.ToUpper(value[0]));
        }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Include { get; set; }

    }

}

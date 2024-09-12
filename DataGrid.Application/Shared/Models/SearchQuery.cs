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
            set => sortBy = !string.IsNullOrEmpty(value) ? value.Replace(value[0], char.ToUpper(value[0])) : sortBy;
        }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Include { get; set; }
        public List<RangeSearch> RangeSearch { get; set; }
        public string NestedSearch { get; set; }
        public string NestedSearchField { get; set; }
        public int NestedSearchValue { get; set; }


    }

}

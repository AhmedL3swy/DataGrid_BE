using MediatR;

namespace DataGrid.Application.Shared.Models
{
    public class SearchQueryV2
    {

        public string SearchKeyword { get; set; }

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
        public List<NestedSearch> NestedSearch { get; set; }


    }

}

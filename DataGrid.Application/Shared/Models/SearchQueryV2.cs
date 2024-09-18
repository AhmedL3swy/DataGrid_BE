using MediatR;
using System.Text.Json.Serialization;

namespace DataGrid.Application.Shared.Models
{
    public class SearchQueryV2
    {

        public List<SearchByKeyword> SearchByKeyword { get; set; }
        public List<RangeSearch> RangeSearch { get; set; }
        public string SortBy { get; set; }       
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        [JsonIgnore]
        public string Include { get; set; }
    }

}

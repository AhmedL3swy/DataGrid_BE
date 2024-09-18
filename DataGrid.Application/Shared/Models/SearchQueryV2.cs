using MediatR;
using System.Text.Json.Serialization;

namespace DataGrid.Application.Shared.Models
{
    public class SearchQueryV2 : SeachQueryEssentials
    {

        public List<SearchByKeyword> SearchByKeyword { get; set; } = [];
        public List<RangeSearch> RangeSearch { get; set; } = [];

    }

}

using DataGrid.Application.Shared.Models;

namespace DataGrid.Api.Controllers
{
    public class ProductSearchDTO : SearchQueryV2
    {
        public string SearchName
        {
            set => SearchByKeyword.Add(new SearchByKeyword { Fields = "arname,enname", Keyword = value });
        }
        public string SearchCategoryName
        {
            set => SearchByKeyword.Add(new SearchByKeyword { Fields = "category.enname,category.arname", Keyword = value });
        }
        public string StartEndDate // Seprate with |
        {
            set
            {
                if (string.IsNullOrEmpty(value) || value == "|") return;
                var dates = value.Split('|');
                RangeSearch.Add(new RangeSearch { Field = "addeddate", Start = dates[0], End = dates[1] });

            }
        }
    }
}
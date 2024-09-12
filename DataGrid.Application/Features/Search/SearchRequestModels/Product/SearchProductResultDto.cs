using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Search.SearchRequestModels.Product
{
    public class SearchProductResultDto
    {
        public int Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string EnDescription { get; set; }
        public string ArDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string EnCategoryName { get; set; }
        public string ArCategoryName { get; set; }
        public DateTime AddedOn { get; set; }
        public DateOnly AddedDate { get; set; }
        public TimeOnly AddedTime { get; set; }


    }
}

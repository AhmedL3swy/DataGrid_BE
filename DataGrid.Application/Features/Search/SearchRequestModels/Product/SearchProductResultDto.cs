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
        public string Name { get; set; }
        public string ArName { get; set; }
        public string Description { get; set; }
        public string ArDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryArName { get; set; }
        public DateTime AddedOn { get; set; }
        public DateOnly AddedData { get; set; }
        public TimeOnly AddedTime { get; set; }


    }
}

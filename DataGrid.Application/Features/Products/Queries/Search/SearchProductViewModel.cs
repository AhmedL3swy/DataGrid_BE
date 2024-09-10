using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Products.Queries.Search
{
    public class SearchProductViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ar_Name { get; set; }
        public string? Description { get; set; }
        public string? ar_Description { get; set; }
        public decimal? Price { get; set; }
        public int? stock { get; set; }
    }
}

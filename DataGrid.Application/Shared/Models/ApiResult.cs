using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Shared.Models
{
    public class ApiResult<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}

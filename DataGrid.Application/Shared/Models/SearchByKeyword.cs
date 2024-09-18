using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Shared.Models
{
    public class SearchByKeyword
    {
        public string Fields { get; set; } // Fields to search separated by comma
        public string Keyword { get; set; }
        [JsonIgnore]
        public List<string> FieldList
        {
            get
            {
                return Fields.Split(',').ToList();
            }
        }
    }
}

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataGrid.Application.Shared.Models
{
    public class RangeSearch
    {
        public string Field { get; set; }
        public decimal Start { get; set; }
        public decimal End { get; set; }
        public int StartInt { get; set; }
        public int EndInt { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}

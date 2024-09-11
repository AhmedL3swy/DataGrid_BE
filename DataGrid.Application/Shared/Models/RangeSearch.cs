using System;
using System.Text.Json.Serialization;

namespace DataGrid.Application.Shared.Models
{
    public class RangeSearch
    {
        public string Field { get; set; }

        // Input properties
        public decimal Start { get; set; }
        public decimal End { get; set; }

        [JsonIgnore]
        public int StartInt => (int)Start; 
        [JsonIgnore]
        public int EndInt => (int)End;     

        [JsonIgnore]
        public DateTime StartDateTime { get; private set; }
        [JsonIgnore]
        public DateTime EndDateTime { get; private set; }

        private string _startDate;
        private string _endDate;

        public string StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                ParseStartDate();
            }
        }

        public string EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                ParseEndDate();
            }
        }

        [JsonIgnore]
        public DateOnly ParsedStartDate { get; private set; }
        [JsonIgnore]
        public DateOnly ParsedEndDate { get; private set; }

        private void ParseStartDate()
        {
            if (DateOnly.TryParse(_startDate, out DateOnly parsedDate))
            {
                ParsedStartDate = parsedDate;
                StartDateTime = parsedDate.ToDateTime(new TimeOnly(0, 0));
            }
        }

        private void ParseEndDate()
        {
            if (DateOnly.TryParse(_endDate, out DateOnly parsedDate))
            {
                ParsedEndDate = parsedDate;
                EndDateTime = parsedDate.ToDateTime(new TimeOnly(0, 0));
            }
        }
    }
}

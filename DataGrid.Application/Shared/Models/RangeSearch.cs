using System;
using System.Text.Json.Serialization;

namespace DataGrid.Application.Shared.Models
{
    public class RangeSearch
    {
        public string Field { get; set; }

        // Input properties
        public string start;
        public string Start
        {
            get => start;
            set
            {
                start = value;
                ParseValues();
            }
        }
        public string end;
        public string End
        {
            get => end;
            set
            {
                end = value;
                ParseValues();
            }
        }

        [JsonIgnore]
        public decimal StartDecimal { get; private set; }
        [JsonIgnore]
        public decimal EndDecimal { get; private set; }

        [JsonIgnore]
        public int StartInt { get; private set; }
        [JsonIgnore]
        public int EndInt { get; private set; }

        [JsonIgnore]
        public DateOnly StartDateOnly { get; private set; }
        [JsonIgnore]
        public DateOnly EndDateOnly { get; private set; }

        [JsonIgnore]
        public DateTime StartDateTime { get; private set; }
        [JsonIgnore]
        public DateTime EndDateTime { get; private set; }



        private void ParseValues()
        {

            if (decimal.TryParse(Start, out decimal parsedStart))
            {
                StartDecimal = parsedStart;
                StartInt = (int)parsedStart;
            }

            if (decimal.TryParse(End, out decimal parsedEnd))
            {
                EndDecimal = parsedEnd;
                EndInt = (int)parsedEnd;
            }

            if (DateOnly.TryParse(Start, out DateOnly parsedStartDateOnly))
            {
                StartDateOnly = parsedStartDateOnly;
                StartDateTime = parsedStartDateOnly.ToDateTime(new TimeOnly(0, 0));
            }

            if (DateOnly.TryParse(End, out DateOnly parsedEndDateOnly))
            {
                EndDateOnly = parsedEndDateOnly;
                EndDateTime = parsedEndDateOnly.ToDateTime(new TimeOnly(23, 59));
            }
        }
    }
}

using Newtonsoft.Json;
using System;

namespace ParseJson
{
    public class Search
    {
        private DateTime StartDateType;
        private DateTime EndDateType;

        public string startDate { get; set; }
        public string endDate { get; set; }

        [JsonIgnore]
        public int startDateOfYear
        {
            get
            {
                if (DateTime.TryParse(startDate, out StartDateType))
                    return StartDateType.DayOfYear;
                else
                    return 0;
            }
        }
        [JsonIgnore]
        public int endDateOfYear
        {
            get
            {
                if (DateTime.TryParse(endDate, out EndDateType))
                    return EndDateType.DayOfYear;
                else
                    return 0;
            }
        }
    }
}

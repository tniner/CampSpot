using Newtonsoft.Json;
using System;

namespace ParseJson
{
    public class Reservation
    {
        private DateTime StartDateType;
        private DateTime EndDateType;

        public int campsiteId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

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

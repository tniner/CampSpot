using Newtonsoft.Json;
using System.Collections.Generic;

namespace ParseJson
{
    public class RootObject
    {
        public Search search { get; set; }
        public List<Campsite> campsites { get; set; }
        public List<Reservation> reservations { get; set; }
    }
}

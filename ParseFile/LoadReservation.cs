using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseJson
{
    public class LoadReservation
    {
        public Dictionary<int, List<int>> LoadReservationsList(IEnumerable<int> campSiteIds, RootObject root)
        {
            Dictionary<int, List<int>> reservationsList = new Dictionary<int, List<int>>();
            List<int> reservedDates;

            foreach (var campsiteId in campSiteIds)
            {
                List<Reservation> reservationsByCampSite = root.reservations.Where(r => campsiteId == r.campsiteId).ToList();

                reservedDates = new List<int>();
                foreach (Reservation reservation in reservationsByCampSite)
                {
                    for (int i = reservation.startDateOfYear; i <= reservation.endDateOfYear; i++)
                    {
                        reservedDates.Add(i);
                    }
                }
                reservationsList.Add(campsiteId, reservedDates);
            }

            return reservationsList;
        }
    }
}

using System.Collections.Generic;

namespace BusinessRules
{
    public class GapRule
    {
        bool validReservation;
        public List<int> ApplyGapRule(Dictionary<int, List<int>>reservationsList, IEnumerable<int> campSiteIds, int startDateOfYear, int endDateOfYear, int gap)
        {
            var campsites = new List<int>();

            foreach (var campsiteId in campSiteIds)
            {
                validReservation = true;

                var resList = reservationsList[campsiteId];
                for (int i = startDateOfYear; i <= endDateOfYear; i++)
                {
                    if (resList.Contains(i))
                    {
                        validReservation = false;
                        break;
                    }
                }
                if (!validReservation)
                    continue;

                if (!resList.Contains(startDateOfYear - 1))
                {  
                    for (int i = 1; i <= gap; i++)
                    {
                        if (resList.Contains(startDateOfYear - (gap + 1) ))
                        {
                            validReservation = false;
                            break;
                        }
                    }
                }
                if (!validReservation)
                    continue;

                if (!resList.Contains(endDateOfYear + 1))
                {
                    for (int i = 1; i <= gap; i++)
                    {
                        if (resList.Contains(endDateOfYear + (gap + 1) ))
                        {
                            validReservation = false;
                            break;
                        }
                    }
                }
                if (!validReservation)
                    continue;

                campsites.Add(campsiteId);
            }

            return campsites;
        }
    }
}

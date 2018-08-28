using ParseJson;
using BusinessRules;
using System;
using System.IO;
using System.Linq;

namespace CampSpot
{
    public class Program
    {
        private static string filename = @"C:\Users\tnine\OneDrive\Documents\Visual Studio 2017\Projects\CampSpot\test-case.json";

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                filename = args[0];
            }

            if (File.Exists(filename))
            {
                Console.WriteLine("Processing " + filename);
            }
            else
            {            
                Console.WriteLine("Please provdie a fully qualified json filename");
            }

            var parseFile = new ParseFile<RootObject>();
            var root = parseFile.ReadJsonFile(filename);
            var campSiteIds = root.campsites.Select(s => s.id);

            var loadReservation = new LoadReservation();
            var reservationsList = loadReservation.LoadReservationsList(campSiteIds, root);
            
            var gapRule = new GapRule();
            var campsites = gapRule.ApplyGapRule(reservationsList, campSiteIds, root.search.startDateOfYear, root.search.endDateOfYear, 1);

            foreach (int campsiteId in campsites)
            {
                Console.WriteLine(root.campsites.Find(c => c.id == campsiteId).name);
            }

            Console.WriteLine("Press ESC to stop");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
            }
        }

    }
}

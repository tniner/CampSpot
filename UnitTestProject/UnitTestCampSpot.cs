using BusinessRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseJson;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private static string filename = @"C:\Users\tnine\OneDrive\Documents\Visual Studio 2017\Projects\CampSpot\test-case.json";

        [TestMethod]
        public void AllValidCampSiteIds()
        {
            var parseFile = new ParseFile<RootObject>();
            var root = parseFile.ReadJsonFile(filename);
            var campSiteIds = root.campsites.Select(s => s.id);

            var loadReservation = new LoadReservation();
            var reservationsList = loadReservation.LoadReservationsList(campSiteIds, root);

            var gapRule = new GapRule();
            var campsites = gapRule.ApplyGapRule(reservationsList, campSiteIds, root.search.startDateOfYear, root.search.endDateOfYear, 1);

            CollectionAssert.AreEqual(campsites, new List<int>(new int[] { 2, 4, 5 }));
        }

        [TestMethod]
        public void AllValidCampSiteNames()
        {
            var parseFile = new ParseFile<RootObject>();
            var root = parseFile.ReadJsonFile(filename);
            var campSiteIds = root.campsites.Select(s => s.id);

            var loadReservation = new LoadReservation();
            var reservationsList = loadReservation.LoadReservationsList(campSiteIds, root);

            var gapRule = new GapRule();
            var campsites = gapRule.ApplyGapRule(reservationsList, campSiteIds, root.search.startDateOfYear, root.search.endDateOfYear, 1);

            List<string> campSiteNames = new List<string>();
            foreach (int campsiteId in campsites)
            {
                campSiteNames.Add(root.campsites.Find(c => c.id == campsiteId).name);
            }

            CollectionAssert.AreEqual(campSiteNames, new List<string>(new string[] { "Comfy Cabin", "Rickety Cabin", "Cabin in the Woods" }));
        }
    }
}

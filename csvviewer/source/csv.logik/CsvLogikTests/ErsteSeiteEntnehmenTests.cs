using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csv.logik;

namespace CsvLogikTests
{
    [TestClass]
    public class ErsteSeiteEntnehmenTests
    {
        [TestMethod]
        public void CompletePagePresentTest()
        {
            string[] input = new string[] {"H1;H2;H3", "a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o"};
            CsvLogik logik = new CsvLogik();
            var ergebnisTupel = logik.Ermittle_erste_Seitennummer(input);

            Tuple<string, IEnumerable<string>> actual = logik.Entnehme_Seite(ergebnisTupel);
            Tuple<string, IEnumerable<string>> expected = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i",
                                                                                                         "j;k;l",
                                                                                                         "m;n;o"
                                                                                                     });

            Assert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEquivalent(expected.Item2.ToList(), actual.Item2.ToList());

        }

        [TestMethod]
        public void MoreThanOnePageTest()
        {
            string[] input = new string[] { "H1;H2;H3", "a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o"};
            CsvLogik logik = new CsvLogik();
            var ergebnisTupel = logik.Ermittle_erste_Seitennummer(input);

            Tuple<string, IEnumerable<string>> actual = logik.Entnehme_Seite(ergebnisTupel);
            Tuple<string, IEnumerable<string>> expected = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i",
                                                                                                         "j;k;l",
                                                                                                         "m;n;o"
                                                                                                     });

            Assert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEquivalent(expected.Item2.ToList(), actual.Item2.ToList());

        }

        [TestMethod]
        public void NextToAFullPageTest()
        {
            string[] input = new string[] { "H1;H2;H3", "1a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "2a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "3a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o" };
            CsvLogik logik = new CsvLogik();
            var ergebnisTupel = logik.Ermittle_erste_Seitennummer(input);

            
            ergebnisTupel = logik.Ermittle_nächste_Seitennummer(input);
            Tuple<string, IEnumerable<string>> actual = logik.Entnehme_Seite(ergebnisTupel);
            Tuple<string, IEnumerable<string>> expected = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "2a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i",
                                                                                                         "j;k;l",
                                                                                                         "m;n;o"
                                                                                                     });

            Assert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEquivalent(expected.Item2.ToList(), actual.Item2.ToList());

        }

        [TestMethod]
        public void NextToALastFullPageTest()
        {
            string[] input = new string[] { "H1;H2;H3", "1a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "2a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "3a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o" };
            CsvLogik logik = new CsvLogik();
            var ergebnisTupel = logik.Ermittle_erste_Seitennummer(input);


            ergebnisTupel = logik.Ermittle_nächste_Seitennummer(input);
            ergebnisTupel = logik.Ermittle_nächste_Seitennummer(input);
            Tuple<string, IEnumerable<string>> actual = logik.Entnehme_Seite(ergebnisTupel);
            Tuple<string, IEnumerable<string>> expected = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "3a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i",
                                                                                                         "j;k;l",
                                                                                                         "m;n;o"
                                                                                                     });

            Assert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEquivalent(expected.Item2.ToList(), actual.Item2.ToList());

        }

        [TestMethod]
        public void NextToALastIncompletePageTest()
        {
            string[] input = new string[] { "H1;H2;H3", "1a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "2a;b;c", "d;e;f", "g;h;i", "j;k;l", "m;n;o", "3a;b;c", "d;e;f", "g;h;i" };
            CsvLogik logik = new CsvLogik();
            var ergebnisTupel = logik.Ermittle_erste_Seitennummer(input);


            ergebnisTupel = logik.Ermittle_nächste_Seitennummer(input);
            ergebnisTupel = logik.Ermittle_nächste_Seitennummer(input);
            Tuple<string, IEnumerable<string>> actual = logik.Entnehme_Seite(ergebnisTupel);
            Tuple<string, IEnumerable<string>> expected = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "3a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i"
                                                                                                     });

            Assert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEquivalent(expected.Item2.ToList(), actual.Item2.ToList());

        }

        [TestMethod]
        public void PageIncompleteTest()
        {
            string[] input = new string[] { "H1;H2;H3", "a;b;c", "d;e;f", "g;h;i", "j;k;l"};
            CsvLogik logik = new CsvLogik();
            var ergebnisTupel = logik.Ermittle_erste_Seitennummer(input);

            Tuple<string, IEnumerable<string>> actual = logik.Entnehme_Seite(ergebnisTupel);
            Tuple<string, IEnumerable<string>> expected = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i",
                                                                                                         "j;k;l"
                                                                                                     });

            Assert.AreEqual(expected.Item1, actual.Item1);
            CollectionAssert.AreEquivalent(expected.Item2.ToList(), actual.Item2.ToList());

        }
    }
}

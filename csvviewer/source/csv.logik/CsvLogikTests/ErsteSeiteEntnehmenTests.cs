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
            Tuple<string, IEnumerable<string>> actual = logik.Erste_Seite_entnehmen(input);
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
        public void PageIncompleteTest()
        {
            string[] input = new string[] { "H1;H2;H3", "a;b;c", "d;e;f", "g;h;i", "j;k;l"};
            CsvLogik logik = new CsvLogik();
            Tuple<string, IEnumerable<string>> actual = logik.Erste_Seite_entnehmen(input);
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

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csv.logik;

namespace CsvLogikTests
{
    [TestClass]
    public class FormatierenSeiteTests
    {
        [TestMethod]
        public void FormatiereSeiteTest()
        {
            CsvLogik logik = new CsvLogik();
            Tuple<string, IEnumerable<string>> input = new Tuple<string, IEnumerable<string>>("H1;H2;H3",
                                                                                                 new List<string>
                                                                                                     {
                                                                                                         "a;b;c",
                                                                                                         "d;e;f",
                                                                                                         "g;h;i",
                                                                                                         "j;k;l"
                                                                                                     });
            IEnumerable<string> expected = new string[] { "H1;H2;H3", "a;b;c", "d;e;f", "g;h;i", "j;k;l" };
            IEnumerable<string> actual = logik.Formatiere_Seite(input);

            CollectionAssert.AreEquivalent(expected.ToArray(), actual.ToArray());

        }
    }
}

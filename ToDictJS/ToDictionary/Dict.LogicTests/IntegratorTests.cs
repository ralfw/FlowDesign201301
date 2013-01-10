using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dict.LogicTests
{
    [TestClass]
    public class IntegratorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Integrator.Integrator integr = new Integrator.Integrator();
            Dictionary<string, string> actual = integr.ToDictionary("a=3;;b=Hallo;b=ja;C;");
            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected.Add("a","3");
            expected.Add("b","ja");
            expected.Add("C","");

            CollectionAssert.AreEquivalent(expected.Keys, actual.Keys);
            CollectionAssert.AreEquivalent(expected.Values, actual.Values);
        }
    }
}

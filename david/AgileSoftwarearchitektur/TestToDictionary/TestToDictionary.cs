using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDictionary;

namespace TestToDictionary
{
    [TestClass]
    public class TestToDictionary
    {
        [TestMethod]
        public void EverythingIsFineTest()
        {
            string config = "a=1;b=hallo;c=david schäfer";
            var expectedObject = new Dictionary<string, string> {{"a", "1"}, {"b", "hallo"}, {"c", "david schäfer"}};

            var todicitonary = new ToDictionary.ToDictionary();
            var actualObject = todicitonary.ToDictionaryMethod(config);

            CollectionAssert.AreEquivalent(expectedObject.Keys, actualObject.Keys);
            CollectionAssert.AreEquivalent(expectedObject.Values, actualObject.Values);
        }

        [TestMethod]
        public void InputNullTest()
        {
            string config = null;
            bool errorOccur = false;
            try
            {
                var todicitonary = new ToDictionary.ToDictionary();
                todicitonary.ToDictionaryMethod(config);
            }
            catch (Exception)
            {
                errorOccur = true;
            }
            Assert.IsTrue(errorOccur);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDictionary;

namespace Dict.Integrator
{
    public class Integrator
    {
        public Dictionary<string, string> ToDictionary(string config)
        {
            var logic = new DictionaryCreatorLogic();
            var entries = logic.CreateEntries(config);
            var kvPairs = logic.CreateKeyValuePairs(entries);

            return logic.CreateDictionaryFromKeyValuePairs(kvPairs);
        }
    }
}

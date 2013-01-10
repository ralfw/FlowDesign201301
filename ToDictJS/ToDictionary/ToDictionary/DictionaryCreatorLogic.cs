using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDictionary
{
    public class DictionaryCreatorLogic
    {
        public List<string> CreateEntries(string config)
        {
            List<string> entries = config.Split(';').ToList();
            List<string> result = new List<string>();

            foreach (var entry in entries)
            {
                if(string.IsNullOrEmpty(entry))
                {
                    continue;
                }

                result.Add(entry);
            }

            return result;
        }

        public List<Tuple<string, string>> CreateKeyValuePairs(IEnumerable<string> entries)
        {
            List<Tuple<string, string>> keyValuePairs = new List<Tuple<string, string>>();

            foreach (var entry in entries)
            {
                string[] kvPair = entry.Split('=');
                string key = kvPair[0];
                string value = (kvPair.Length == 2) ? kvPair[1] :"";

                keyValuePairs.Add(new Tuple<string, string>(key, value));
            }

            return keyValuePairs;
        }

        public Dictionary<string, string> CreateDictionaryFromKeyValuePairs(List<Tuple<string, string>> kvPairs)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var kvPair in kvPairs)
            {
                result[kvPair.Item1] = kvPair.Item2;
            }

            return result;
        }
    }
}

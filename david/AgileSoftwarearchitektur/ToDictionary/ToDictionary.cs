using System;
using System.Collections.Generic;
using System.Linq;


namespace ToDictionary
{
    public class ToDictionary
    {
        public Dictionary<string, string> ToDictionaryMethod(string config)
        {
            List<string> stringList = SplitString(config);
            return ConvertStringListToDictionary(stringList);
        }

        public List<string> SplitString(string config)
        {
            if (config == null)
                throw new Exception("Input is null");

            return config.Split(';').ToList();
        }

        public Dictionary<string, string> ConvertStringListToDictionary(List<string> stringList)
        {
            var intermediate = SplitStringListToKeyValue(stringList);
            return AddKeyValuesToDictionary(intermediate);
        }

        public List<KeyValuePair<string,string>> SplitStringListToKeyValue(List<string> stringList)
        {
            var resultList = new List<KeyValuePair<string, string>>();
            foreach (string stringValue in stringList)
            {
                if (stringValue.Contains("="))
                {
                    string key = stringValue.Substring(0, stringValue.IndexOf("=", StringComparison.Ordinal));
                    string value = stringValue.Substring(stringValue.IndexOf("=", StringComparison.Ordinal) + 1);
                    resultList.Add(new KeyValuePair<string, string>(key, value));
                }
                else
                {
                    resultList.Add(new KeyValuePair<string, string>(stringValue,null));
                }
            }
            return resultList;
        }

        public Dictionary<string,string> AddKeyValuesToDictionary(List<KeyValuePair<string,string>> listOfKeyValues)
        {
            var result = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> keyValuePair in listOfKeyValues)
            {
                result[keyValuePair.Key] =keyValuePair.Value;    
            }
            return result;
        }




    }
}

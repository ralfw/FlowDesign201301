using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csv.contracts;

namespace csv.logik
{
    public class CsvLogik : ILogik
    {
        public Tuple<string, IEnumerable<string>> Erste_Seite_entnehmen(string[] rohzeilen)
        {
            if(rohzeilen == null || rohzeilen.Length == 0)
            {
                return new Tuple<string, IEnumerable<string>>("", new List<string>());
            }

            string header = rohzeilen[0];
            List<string> records = new List<string>();
            
            for (int i = 1; i < 6; i++)
            {
                if(rohzeilen.Length<=i)
                {
                    break;
                }

                records.Add(rohzeilen[i]);
            }

            return new Tuple<string, IEnumerable<string>>(header, records);
        }

        public IEnumerable<string> Formatiere_Seite(Tuple<string, IEnumerable<string>> rohseite)
        {
            List<string> formattedPage = new List<string>();
            formattedPage.Add(rohseite.Item1);
            formattedPage.AddRange(rohseite.Item2);

            return formattedPage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csv.contracts;

namespace csv.logik
{
    public class CsvLogik : ILogik
    {
        private const int SeitenLaenge = 5;
        private int _zeilenIndex = 0;
        //public Tuple<string, IEnumerable<string>> Erste_Seite_entnehmen(string[] rohzeilen)
        //{
        //    if(rohzeilen == null || rohzeilen.Length == 0)
        //    {
        //        return new Tuple<string, IEnumerable<string>>("", new List<string>());
        //    }

        //    string header = rohzeilen[0];
        //    List<string> records = new List<string>();
            
        //    for (int i = 1; i < 6; i++)
        //    {
        //        if(rohzeilen.Length<=i)
        //        {
        //            break;
        //        }

        //        records.Add(rohzeilen[i]);
        //    }

        //    return new Tuple<string, IEnumerable<string>>(header, records);
        //}

        public Tuple<string, IEnumerable<string>> Entnehme_Seite(Tuple<int, int, string[]> seiteninfo)
        {
            if (seiteninfo.Item3 == null || seiteninfo.Item3.Length == 0)
            {
                return new Tuple<string, IEnumerable<string>>("", new List<string>());
            }

            string header = seiteninfo.Item3[0];
            List<string> records = new List<string>();
            int letzteZeile = seiteninfo.Item1 + seiteninfo.Item2;
            for (int i = seiteninfo.Item1; i < letzteZeile; i++)
            {
                if (seiteninfo.Item3.Length <= i)
                {
                    break;
                }

                records.Add(seiteninfo.Item3[i]);
            }

            return new Tuple<string, IEnumerable<string>>(header, records);
        }

        public Tuple<int, int, string[]> Ermittle_erste_Seitennummer(string[] rohzeilen)
        {
            _zeilenIndex = 1;

            int berechneteSeitenLange = BerechneSeitelänge(rohzeilen.Length,SeitenLaenge);
            return new Tuple<int, int, string[]>(_zeilenIndex, berechneteSeitenLange, rohzeilen);
        }

        public Tuple<int, int, string[]> Ermittle_nächste_Seitennummer(string[] rohzeilen)
        {
            int newZeilenIndex = _zeilenIndex + SeitenLaenge;
            if (rohzeilen.Length > newZeilenIndex)
                _zeilenIndex = newZeilenIndex;

            int berechneteSeitenLange = BerechneSeitelänge(rohzeilen.Length,SeitenLaenge);
            return new Tuple<int, int, string[]>(_zeilenIndex, berechneteSeitenLange, rohzeilen);
        }

        public IEnumerable<string> Formatiere_Seite(Tuple<string, IEnumerable<string>> rohseite)
        {
            List<string> formattedPage = new List<string>();
            formattedPage.Add(rohseite.Item1);
            formattedPage.AddRange(rohseite.Item2);

            return formattedPage;
        }

        private int BerechneSeitelänge(int feldlänge, int seitenlänge)
        {
            int berechneteSeitenLange = seitenlänge;
            if ((feldlänge - _zeilenIndex) < seitenlänge)
                berechneteSeitenLange = feldlänge - _zeilenIndex;

            return berechneteSeitenLange;
        }
    }
}

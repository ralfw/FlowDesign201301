using System;
using System.Collections.Generic;

namespace csv.contracts
{
    public interface ILogik
    {
        Tuple<string, IEnumerable<string>> Entnehme_Seite(Tuple<int,int,string[]> seiteninfo);
        Tuple<int, int, string[]> Ermittle_erste_Seitennummer(string[] rohzeilen);
        Tuple<int, int, string[]> Ermittle_nächste_Seitennummer(string[] rohzeilen);

        IEnumerable<string> Formatiere_Seite(Tuple<string, IEnumerable<string>> rohseite);
    }
}
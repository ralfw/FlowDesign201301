using System;
using System.Collections.Generic;

namespace csv.contracts
{
    public interface ILogik
    {
        Tuple<string, IEnumerable<string>> Erste_Seite_entnehmen(string[] rohzeilen);
        IEnumerable<string> Formatiere_Seite(Tuple<string, IEnumerable<string>> rohseite);
    }
}
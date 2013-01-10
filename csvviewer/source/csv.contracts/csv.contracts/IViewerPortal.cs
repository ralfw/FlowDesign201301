using System.Collections.Generic;

namespace csv.contracts
{
    public interface IViewerPortal
    {
        void Menü_anzeigen();
        void Zeige_Seite_an(IEnumerable<string> zeilen);
    }
}
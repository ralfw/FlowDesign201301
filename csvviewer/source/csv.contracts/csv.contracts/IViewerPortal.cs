using System.Collections.Generic;

namespace csv.contracts
{
    public interface IViewerPortal
    {
        void Men�_anzeigen();
        void Zeige_Seite_an(IEnumerable<string> zeilen);
    }
}
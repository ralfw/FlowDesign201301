using System;
using System.Collections.Generic;
using csv.contracts;

namespace csv.client
{
    class Integration
    {
        private readonly IStarterPortal _starter;
        private readonly IViewerPortal _viewer;
        private readonly IFileAdapter _file;
        private readonly ILogik _logik;

        public Integration(IStarterPortal starter, IViewerPortal viewer, IFileAdapter file, ILogik logik)
        {
            _starter = starter;
            _viewer = viewer;
            _file = file;
            _logik = logik;
        }

        public void Starten()
        {
            Zeige_erste_Seite();
            _viewer.Menü_anzeigen();
        }

        void Zeige_erste_Seite()
        {
            var rohe_erste_Seite = Hole_Records_erste_Seite();
            var formatierte_Seite = _logik.Formatiere_Seite(rohe_erste_Seite);
            _viewer.Zeige_Seite_an(formatierte_Seite);
        }

        Tuple<string,IEnumerable<string>> Hole_Records_erste_Seite()
        {
            var dateiname = _starter.Dateiname_von_Cmdline_lesen();
            var rohe_zeilen = _file.Alle_Zeilen_laden(dateiname);
            return _logik.Erste_Seite_entnehmen(rohe_zeilen);
        }
    }
}
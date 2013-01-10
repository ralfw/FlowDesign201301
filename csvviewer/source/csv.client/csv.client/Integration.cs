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

            _viewer.N�chste_Seite += Next;
        }


        public void Starten()
        {
            Zeige_erste_Seite();
            _viewer.Men�_anzeigen();
        }


        void Zeige_erste_Seite()
        {
            var rohe_erste_Seite = Hole_Records_erste_Seite();
            var formatierte_Seite = _logik.Formatiere_Seite(rohe_erste_Seite);
            _viewer.Zeige_Seite_an(formatierte_Seite);
        }

        void Next()
        {
            var rohe_n�chste_Seite = Hole_Records_n�chste_Seite();
            var formatierte_Seite = _logik.Formatiere_Seite(rohe_n�chste_Seite);
            _viewer.Zeige_Seite_an(formatierte_Seite);
        }


        Tuple<string,IEnumerable<string>> Hole_Records_erste_Seite()
        {
            var dateiname = _starter.Dateiname_von_Cmdline_lesen();
            var rohe_zeilen = _file.Alle_Zeilen_laden(dateiname);
            return Erste_Seite_entnehmen(rohe_zeilen);
        }

        private Tuple<string, IEnumerable<string>> Hole_Records_n�chste_Seite()
        {
            var dateiname = _starter.Dateiname_von_Cmdline_lesen();
            var rohe_zeilen = _file.Alle_Zeilen_laden(dateiname);
            return N�chste_Seite_entnehmen(rohe_zeilen);
        }


        Tuple<string,IEnumerable<string>> Erste_Seite_entnehmen(string[] rohe_zeilen)
        {
            var seiteninfo = _logik.Ermittle_erste_Seitennummer(rohe_zeilen);
            return _logik.Entnehme_Seite(seiteninfo);
        }
    
        Tuple<string, IEnumerable<string>> N�chste_Seite_entnehmen(string[] rohe_zeilen)
        {
            var seiteninfo = _logik.Ermittle_n�chste_Seitennummer(rohe_zeilen);
            return _logik.Entnehme_Seite(seiteninfo);
        }
    }
}
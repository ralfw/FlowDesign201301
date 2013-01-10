using System;
using System.Collections.Generic;
using csv.contracts;
using npantarhei.runtime.contract;

namespace csv.portale
{
    [EventBasedComponent]
    [InstanceOperations]
    public class ViewerPortal : IViewerPortal
    {
        public void Menü_anzeigen()
        {
            while(true)
            {
                var foregroundcolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("N(ext), P(revious), F(irst), L(ast), ex(it): ");
                Console.ForegroundColor = foregroundcolor;
                var eingabe = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (char.ToLower(eingabe))
                {
                    case 'n':
                        Nächste_Seite();
                        break;
                    case 'f':
                        Erste_Seite();
                        break;
                    case 'x':
                        Exit();
                        return;
                }
            }
        }

        public void Zeige_Seite_an(IEnumerable<string> zeilen)
        {
            foreach (var zeile in zeilen)
            {
                Console.WriteLine(zeile);
            }
        }


        public event Action Erste_Seite;
        public event Action Nächste_Seite;
        public event Action Exit;
    }
}

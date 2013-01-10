using System;
using System.Collections.Generic;
using csv.contracts;

namespace csv.portale
{
    public class ViewerPortal : IViewerPortal
    {
        public void Menü_anzeigen()
        {
            bool run = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("N(ext), P(revious), F(irst), L(ast), e(xit)");
                Console.ForegroundColor = ConsoleColor.Black;
                char eingabe = Console.ReadKey().KeyChar;

                switch (eingabe)
                {
                    case 'n':
                    case 'N':
                        if (Nächste_Seite != null)
                            Nächste_Seite();
                        break;
                    case 'e':
                    case 'E':
                        run = false;
                        break;
                }
            } while (run);


        }

        public void Zeige_Seite_an(IEnumerable<string> zeilen)
        {
            foreach (var zeile in zeilen)
            {
                Console.WriteLine(zeile);
            }
        }

        public event Action Nächste_Seite;
    }
}

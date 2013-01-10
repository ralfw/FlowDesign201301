using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csv.contracts;

namespace csv.portale
{
    public class ViewerPortal : IViewerPortal
    {
        public void Menü_anzeigen()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("N(ext), P(revious), F(irst), L(ast), eX(it)");
            Console.ForegroundColor = ConsoleColor.Black;
            string eingabe=Console.ReadLine();

        }

        public void Zeige_Seite_an(IEnumerable<string> zeilen)
        {
            foreach (var zeile in zeilen)
            {
                Console.WriteLine(zeile);
            }
        }
    }
}

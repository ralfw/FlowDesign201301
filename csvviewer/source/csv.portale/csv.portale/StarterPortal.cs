using System;
using csv.contracts;

namespace csv.portale
{
    public class StarterPortal : IStarterPortal
    {
        public string Dateiname_von_Cmdline_lesen()
        {
            return Environment.GetCommandLineArgs()[1];
        }
    }
}
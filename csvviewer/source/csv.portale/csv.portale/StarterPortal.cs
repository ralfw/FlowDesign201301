using System;
using csv.contracts;
using npantarhei.runtime.contract;

namespace csv.portale
{
    [InstanceOperations]
    public class StarterPortal : IStarterPortal
    {
        public string Dateiname_von_Cmdline_lesen()
        {
            return Environment.GetCommandLineArgs()[1];
        }
    }
}
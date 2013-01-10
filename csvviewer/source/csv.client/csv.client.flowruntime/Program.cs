using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using npantarhei.runtime;
using npantarhei.runtime.config;
using npantarhei.runtime.operations;

namespace csv.client.flowruntime
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new FlowRuntimeConfiguration()
                                .AddStreamsFrom("csv.client.flowruntime.root.flow", Assembly.GetExecutingAssembly())
                                .AddOperations(new AssemblyCrawler(
                                                   Assembly.Load("csv.filesystem"),
                                                   Assembly.Load("csv.logik"),
                                                   Assembly.Load("csv.portale")));

            using(var fr = new FlowRuntime(config, new Schedule_for_sync_depthfirst_processing()))
            {
                fr.Process(".run");                
            }
        }
    }
}

using System.Linq;
using System.Text;
using csv.filesystem;
using csv.logik;
using csv.portale;

namespace csv.client
{
    class Program
    {
        static void Main(string[] args)
        {
            new Integration(
                new StarterPortal(),
                new ViewerPortal(), 
                new FileAdapter(), 
                new CsvLogik()
                ).Starten();
        }
    }
}

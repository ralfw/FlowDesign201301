using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using csv.contracts;

namespace csv.filesystem
{
    public class FileAdapter : csv.contracts.IFileAdapter
    {
        public string[] Alle_Zeilen_laden(string dateiname)
        {
            return  File.ReadAllLines(dateiname, Encoding.UTF8);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMainView.Helpers;

namespace xTextConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> list = PackageScan.StyFromDir("C:\\Program Files\\MiKTeX 2.9\\tex");

            foreach (string s in list)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfMainView.Helpers
{
    public class PackageScan
    {
        static HashSet<string> listStyFiles = new HashSet<string>();
        public static HashSet<string> StyFromDir(string sDir)
        {
            
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    Console.WriteLine("Scan du dossier " + d);
                    foreach (string f in Directory.GetFiles(d, "*.sty"))
                    {
                        //Console.WriteLine(Path.GetFileNameWithoutExtension(f));
                        listStyFiles.Add((Path.GetFileNameWithoutExtension(f)));
                    }
                    StyFromDir(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return listStyFiles;
        }

        
    }
}

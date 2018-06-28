using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class ScanDir 
    {
        public static ScanDir newScanDir()
        {
            ScanDir sc = new ScanDir();
            sc.Id = -1;
            
            return sc;
        }
    }
}

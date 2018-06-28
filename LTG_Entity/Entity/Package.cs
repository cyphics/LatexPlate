using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class Package : DBItem
    {
        public static Package newPackage()
        {
            Package p = new Package();
            p.Id = -1;

            return p;
        }
    }
}

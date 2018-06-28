using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class Macro : DBItem
    {
        public static Macro newMacro()
        {
            Macro m = new Macro();
            m.Id = -1;
            m.Nom = "New Macro";
            return m;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class Environment : DBItem
    {
        public static Environment newEnvironment()
        {
            Environment e = new Environment();
            e.Id = -1;
            e.Nom = "New Environment";
            e.CodeBefore = "";
            e.CodeAfter = "";
            return e;
        }
    }
}

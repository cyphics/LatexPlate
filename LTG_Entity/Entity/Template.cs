using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class Template : DBItem
    {
        public static Template NewTemplate()
        {
            Template x = new Template();
            x.Id = -1;
            x.LangueID = 1;
            x.DocTypeID = 1;
            x.Hyperref = false;
            x.Encoding = true;
            x.Nom = "New Template";
            
            return x;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public class DBItem
    {
        public string Name {
            get
            {
                if (this is Template)
                    return ((Template)this).Nom;
                else if (this is Package)
                    return ((Package)this).Nom;
                else if (this is Environment)
                    return ((Environment)this).Nom;
                else if (this is Macro)
                    return ((Macro)this).Nom;
                else if (this is Meta)
                    return ((Meta)this).Nom;
                else return "";

            }
        }
        public string Description { get; set; }
    }
}

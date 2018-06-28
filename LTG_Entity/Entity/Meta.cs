using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class Meta : DBItem
    {
        public static Meta newMeta()
        {
            Meta m = new Meta();
            m.Id = -1;
            m.Nom = "New Meta";
            return m;
        }
    }
}

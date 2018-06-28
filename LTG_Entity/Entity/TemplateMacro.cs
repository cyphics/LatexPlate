using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class TemplateMacro
    {
        public static TemplateMacro newTemplateMacro(Template t, Macro m)
        {
            TemplateMacro tm = new TemplateMacro();
            tm.Template_FK = t.Id;
            tm.Macro_FK = m.Id;
            return tm;
        }
        
    }
}

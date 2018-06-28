using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class TemplateMeta
    {
        public static TemplateMeta newTemplateMeta(Template t, Meta m)
        {
            TemplateMeta tm = new TemplateMeta();
            tm.Template_FK = t.Id;
            tm.Meta_FK = m.Id;

            return tm;
        }
    }
}

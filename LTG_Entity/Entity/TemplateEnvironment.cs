using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class TemplateEnvironment
    {
        public static TemplateEnvironment newTemplateEnvironment(Template t, Environment e)
        {
            TemplateEnvironment te = new TemplateEnvironment();
            te.Environment_FK = e.Id;
            te.Template_FK = t.Id;

            return te;
        }
    }
}

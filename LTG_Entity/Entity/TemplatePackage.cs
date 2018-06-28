using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTG_Entity
{
    public partial class TemplatePackage
    {
        public static TemplatePackage newTemplatePackage(Template t, Package p)
        {
            TemplatePackage tp = new TemplatePackage();
            tp.Template_FK = t.Id;
            tp.Package_FK = p.Id;
            return tp;
        }
    }
}

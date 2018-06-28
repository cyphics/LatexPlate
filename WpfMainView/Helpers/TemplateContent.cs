using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMainView.Helpers
{
    public class TemplateContent
    {
        public HashSet<Package> AddedPackages = new HashSet<Package>();
        public HashSet<Macro> AddedMacros = new HashSet<Macro>();
        public HashSet<LTG_Entity.Environment> AddedEnv = new HashSet<LTG_Entity.Environment>();
        public HashSet<Meta> AddedMetas = new HashSet<Meta>();
        public Langue Langue { get; set; }
        public DocType DocType { get; set; }

        private Template _currentTemplate;
        public Template CurrentTemplate
        {
            get { return _currentTemplate; }
            set { _currentTemplate = value; }
        }

        public TemplateContent(Template template)
        {
            CurrentTemplate = template;
            Langue = template.Langue;
            DocType = template.DocType;
            ComputeContent();
        }


        public void Add(Package p)
        {
            bool add = true;
            foreach (Package pack in AddedPackages)
            {
                if (pack.Nom == p.Nom)
                {
                    add = false;
                }
            }

            if (add)
            {
                AddedPackages.Add(p);
            }
        }

        public void Add(Macro m)
        {
            bool add = true;
            foreach (Macro macro in AddedMacros)
            {
                if (macro.Nom == m.Nom)
                {
                    add = false;
                }
            }

            if (add)
            {
                // Add the macro
                AddedMacros.Add(m);
                // Add the packages dependencies
                foreach (Package p in Linq.ListPackages(m))
                {
                    Add(p);
                }
            }
        }
        public void Add(LTG_Entity.Environment e)
        {
            bool add = true;
            foreach (LTG_Entity.Environment env in AddedEnv)
            {
                if (env.Nom == e.Nom)
                {
                    add = false;
                }
            }

            if (add)
            {
                // Add the environment
                AddedEnv.Add(e);
                // Add the packages dependencies
                foreach (Package p in Linq.ListPackages(e))
                {
                    Add(p);
                }
            }
        }

        public void Add(Meta meta)
        {
            bool add = true;
            foreach (Meta m in AddedMetas)
            {
                if (meta.Nom == m.Nom)
                {
                    add = false;
                }
            }

            if (add)
            {
                // Add the meta
                AddedMetas.Add(meta);
                foreach (Meta meta2 in Linq.ListMetas(meta))
                {
                    Add(meta2);
                }
                // Add its related macros
                foreach (Macro m in Linq.ListMacros(meta))
                {
                    Add(m);
                }
                // Add its related environments
                foreach (LTG_Entity.Environment e in Linq.ListEnvironments(meta))
                {
                    Add(e);
                }
                // Add its related packages
                foreach (Package p in Linq.ListPackages(meta))
                {
                    Add(p);
                }
            }
        }

        private void ComputeContent()
        {
            // Get list of META
            // For every META :
            //   -- Get macro
            //   -- Get env
            //   -- Get packages
            // For every macro
            //   -- Get pack
            // For every env
            //   -- Get pack


            foreach (Meta meta in Linq.ListMetas(CurrentTemplate))
            {
                Add(meta);
            }

            foreach (Macro macro in Linq.ListMacros(CurrentTemplate))
            {
                Add(macro);
            }

            foreach (LTG_Entity.Environment env in Linq.ListEnvironments(CurrentTemplate))
            {
                Add(env);
            }

            foreach (Package package in Linq.ListPackages(CurrentTemplate))
            {
                Add(package);
            }



        }
    }
}

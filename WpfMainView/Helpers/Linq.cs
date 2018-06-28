using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfMainView.Controls.UCListDisplaySearch;
using static WpfMainView.Helpers.VMHelper;

namespace WpfMainView.Helpers
{
    class Linq
    {
        static public HashSet<Meta> ListMetas(Template t)
        {
            var query = from meta in App.Entities.Metas
                        where meta.TemplateMetas.Any(template => template.Template_FK == t.Id)
                        select meta;

            return new HashSet<Meta>(query);
        }

        static public HashSet<Meta> ListMetas(Meta m)
        {
            var query = from meta in App.Entities.Metas
                        where meta.Meta1.Any(meta2 => meta2.Id == m.Id)
                        select meta;
            return new HashSet<Meta>(query);
        }
        static public List<Package> ListPackages(Template t)
        {

            var query = from package in App.Entities.Packages
                        where package.TemplatePackages.Any(template => template.Template_FK == t.Id)
                        select package;
            
            return new List<Package>(query);
        }
        static public List<Macro> ListMacros(Template t)
        {
            var query = from env in App.Entities.Macroes
                        where env.TemplateMacroes.Any(template => template.Template_FK == t.Id)
                        select env;

            return new List<Macro>(query);
        }
        static public List<LTG_Entity.Environment> ListEnvironments(Template t)
        {
            var query = from env in App.Entities.Environments
                        where env.TemplateEnvironments.Any(template => template.Template_FK == t.Id)
                        select env;

            return new List<LTG_Entity.Environment>(query);
        }
        static public List<Package> ListPackages(Meta m)
        {
            var query = from package in App.Entities.Packages
                        where package.Metas.Any(meta => meta.Id == m.Id)
                        select package;

            return new List<Package>(query);
        }
        static public List<Package> ListPackages(LTG_Entity.Environment x)
        {

            var query = from package in App.Entities.Packages
                        where package.Environments.Any(elem => elem.Id == x.Id)
                        select package;

            return new List<Package>(query);
        }
        static public List<Package> ListPackages(Macro x)
        {

            var query = from package in App.Entities.Packages
                        where package.Macroes.Any(elem => elem.Id == x.Id)
                        select package;

            return new List<Package>(query);
        }
        
        static public List<Macro> ListMacros(Meta m)
        {

            var query = from macro in App.Entities.Macroes
                        where macro.Metas.Any(meta => meta.Id == m.Id)
                        select macro;

            return new List<Macro>(query);
        }
        static public List<LTG_Entity.Environment> ListEnvironments(Meta m)
        {
            var query = from env in App.Entities.Environments
                        where env.Metas.Any(meta => meta.Id == m.Id)
                        select env;

            return new List<LTG_Entity.Environment>(query);
        }

        static public ObservableCollection<DBItem> DependenciesList (Template t, DBItemType type)
        {
            ObservableCollection<DBItem> list = new ObservableCollection<DBItem>();
            switch (type)
            {
                case DBItemType.Macro:
                    foreach (TemplateMacro tm in t.TemplateMacroes)
                    {
                        list.Add(tm.Macro);
                    }
                    break;
                case DBItemType.Package:
                    foreach (TemplatePackage tp in t.TemplatePackages)
                    {
                        list.Add(tp.Package);
                    }
                    break;
                case DBItemType.Meta:
                    foreach (TemplateMeta tm in t.TemplateMetas)
                    {
                        list.Add(tm.Meta);
                    }
                    break;
                case DBItemType.Environment:
                    foreach (TemplateEnvironment te in t.TemplateEnvironments)
                    {
                        list.Add(te.Environment);
                    }
                    break;
                default:
                    break;

            }
            
            return list;

        }
        static public ObservableCollection<DBItem> DependenciesList(Macro m, DBItemType type)
        {
            ObservableCollection<DBItem> list = new ObservableCollection<DBItem>();


            foreach (Package p in m.Packages)
            {
                list.Add(p);
            }
            return list;
        }
        static public ObservableCollection<DBItem> DependenciesList(LTG_Entity.Environment e, DBItemType type)
        {
            ObservableCollection<DBItem> list = new ObservableCollection<DBItem>();


            foreach (Package p in e.Packages)
            {
                list.Add(p);
            }
            return list;
        }
        static public ObservableCollection<DBItem> DependenciesList(Meta m, DBItemType type)
        {
            ObservableCollection<DBItem> list = new ObservableCollection<DBItem>();

            switch (type)
            {

                case DBItemType.Macro:
                    foreach (Macro ma in m.Macroes)
                    {
                        list.Add(ma);
                    }
                    break;
                case DBItemType.Package:
                    foreach (Package p in m.Packages)
                    {
                        list.Add(p);
                    }
                    break;
                case DBItemType.Meta:
                    foreach (Meta m2 in m.Metas)
                    {
                        list.Add(m2);
                    }
                    break;
                case DBItemType.Environment:
                    foreach (LTG_Entity.Environment e in m.Environments)
                    {
                        list.Add(e);
                    }
                    break;
                default:
                    break;
            }

            return list;
            
        }

        static public void RemoveJoin(Template t, Package p)
        {
            foreach (TemplatePackage tp in App.Entities.TemplatePackages)
            {
                if (tp.Template == t)
                {
                    if (tp.Package == p)
                    {
                        App.Entities.TemplatePackages.Remove(tp);
                    }
                }
            }

            App.Entities.SaveChanges();
        }
        static public void RemoveJoin(Template t, Macro m)
        {
            foreach (TemplateMacro tm in App.Entities.TemplateMacroes)
            {
                if (tm.Template == t)
                {
                    if (tm.Macro== m)
                    {
                        App.Entities.TemplateMacroes.Remove(tm);
                    }
                }
            }

            App.Entities.SaveChanges();
        }
        static public void RemoveJoin(Template t, Meta m)
        {
            foreach (TemplateMeta tm in App.Entities.TemplateMetas)
            {
                if (tm.Template == t)
                {
                    if (tm.Meta== m)
                    {
                        App.Entities.TemplateMetas.Remove(tm);
                    }
                }
            }

            App.Entities.SaveChanges();
        }
        static public void RemoveJoin(Template t, LTG_Entity.Environment e)
        {
            foreach (TemplateEnvironment te in App.Entities.TemplateEnvironments)
            {
                if (te.Template == t)
                {
                    if (te.Environment== e)
                    {
                        App.Entities.TemplateEnvironments.Remove(te);
                    }
                }
            }

            App.Entities.SaveChanges();
        }


    }
}

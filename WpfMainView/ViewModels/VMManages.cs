using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTG_Entity;
using System.Collections.ObjectModel;
using static WpfMainView.ViewModels.VMListDisplaySearch;
using static WpfMainView.Controls.UCListDisplaySearch;
using WpfMainView.Helpers;
using GalaSoft.MvvmLight.CommandWpf;
using WpfMainView.Views;
using System.Data.Entity.Infrastructure;
using static WpfMainView.Helpers.VMHelper;
using System.Windows.Data;
using System.Windows;

namespace WpfMainView.ViewModels
{
    class VMManages : VMBaseViewModel
    {
        private DBItemType CurrentType { get; set; }
        private IDialogCoordinator _dialogCoordinator = DialogCoordinator.Instance;

        // ObsCollection declaration
        private ObservableCollection<Template> _listTemplates;
        public ObservableCollection<Template> ListTemplates
        {
            get { return _listTemplates; }
            set { _listTemplates = value;
                FirePropertyChanged();
            }
        }

        private ObservableCollection<Macro> _listMacros;
        public ObservableCollection<Macro> ListMacros
        {
            get { return _listMacros; }
            set { _listMacros = value;
                FirePropertyChanged();
            }
        }
        private ObservableCollection<LTG_Entity.Environment> _listEnvironments;
        public ObservableCollection<LTG_Entity.Environment> ListEnvironments
        {
            get { return _listEnvironments; }
            set { _listEnvironments = value;
                FirePropertyChanged();
            }
        }
        private ObservableCollection<Meta> _listMetas;
        public ObservableCollection<Meta> ListMetas
        {
            get { return _listMetas; }
            set { _listMetas = value;
                FirePropertyChanged();
            }
        }
        private ObservableCollection<DocType> _listDocTypes;
        public ObservableCollection<DocType> ListDocTypes
        {
            get { return _listDocTypes; }
            set {
                _listDocTypes = value;
                FirePropertyChanged();
            }
        }
        private ObservableCollection<Langue> _listLangues;
        public ObservableCollection<Langue> ListLangues
        {
            get { return _listLangues; }
            set { _listLangues = value;
                FirePropertyChanged();
            }
        }
        private ObservableCollection<DBItem> _currentList;
        public ObservableCollection<DBItem> ManagedList
        {
            get { return _currentList; }
            set {
                _currentList = value;
                FirePropertyChanged();
                
            }
        }
        private DBItem _current;
        public DBItem ManagedItem
        {
            get { return _current; }
            set
            {
                _current = value;

                if (value != null)
                {
                    try
                    {
                        switch (CurrentType)
                        {
                            case DBItemType.Template:
                                break;
                            case DBItemType.Macro:
                                Code = ((Macro)ManagedItem).Code;
                                break;
                            case DBItemType.Meta:
                                break;
                            case DBItemType.Environment:
                                Code = ((LTG_Entity.Environment)ManagedItem).CodeBefore;
                                Code2 = ((LTG_Entity.Environment)ManagedItem).CodeAfter;
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("In ManagedItem \n" + e); ;
                    }
                   
                }

                FirePropertyChanged();
                FirePropertyChanged("HasItem");
            }
        }
        CollectionViewSource view = new CollectionViewSource();
        

        private string _code;

        public string Code
        {
            get { return _code; }
            set {
                _code = value;
                switch (CurrentType)
                {
                    case DBItemType.Macro:
                        ((Macro)ManagedItem).Code = _code;
                        break;
                    case DBItemType.Environment:
                        ((LTG_Entity.Environment)ManagedItem).CodeBefore = value;
                        break;
                    default:
                        break;
                }

                FirePropertyChanged();
            }
        }

        private string _code2;

        public string Code2
        {
            get { return _code2; }
            set
            {
                _code2 = value;
                ((LTG_Entity.Environment)ManagedItem).CodeAfter = value;
                FirePropertyChanged();
            }
        }


        // Constructor
        public VMManages()
        {
            Init();
            CommandeSauver = new RelayCommand(Sauver);
            CommandeNouveau = new RelayCommand(Nouveau);
            CommandeEffacer = new RelayCommand(Effacer);
            CommandeGenerer = new RelayCommand(CreateWindowGenerate);


        }
        private void Init()
        {
            ListTemplates = new ObservableCollection<Template>(App.Entities.Templates);

            ListMacros = new ObservableCollection<Macro>(App.Entities.Macroes);
            ListMetas = new ObservableCollection<Meta>(App.Entities.Metas);
            ListEnvironments = new ObservableCollection<LTG_Entity.Environment>(App.Entities.Environments);
            ListDocTypes = new ObservableCollection<DocType>(App.Entities.DocTypes);
            ListLangues = new ObservableCollection<Langue>(App.Entities.Langues);
            BoutonPackages = new RelayCommand(BtnPackages);
            BoutonMacros = new RelayCommand(BtnMacros);
            BoutonMetas = new RelayCommand(BtnMetas);
            BoutonEnvironments = new RelayCommand(BtnEnvs);
            CommandeEffacer = new RelayCommand(Effacer);
        }

        public void ChangeManager(DBItemType type)
        {
            //App.Entities.SaveChanges();
            

            switch (type)
            {

                case DBItemType.Macro:
                    CurrentType = DBItemType.Macro;
                    ManagedList = new ObservableCollection<DBItem>(ListMacros);
                    break;
                case DBItemType.Meta:
                    CurrentType = DBItemType.Meta;
                    ManagedList = new ObservableCollection<DBItem>(ListMetas);
                    break;
                case DBItemType.Environment:
                    CurrentType = DBItemType.Environment;
                    ManagedList = new ObservableCollection<DBItem>(ListEnvironments);
                    break;
                case DBItemType.Template:
                default:
                    CurrentType = DBItemType.Template;
                    ManagedList = new ObservableCollection<DBItem>(ListTemplates);
                   

                    break;
            }
            ManagedItem = null;

            FirePropertyChanged("HasManagedList");
        }

        public void FiltrerListe(string filtre)
        {
            switch (CurrentType)
            {
                case DBItemType.Template:
                    this.ListTemplates = new ObservableCollection<Template>(
                    App.Entities.Templates.Where(a => a.Nom.Contains(filtre)));
                    this.ManagedList = new ObservableCollection<DBItem>(ListTemplates);
                    break;
                case DBItemType.Macro:
                    this.ListMacros = new ObservableCollection<Macro>(
                    App.Entities.Macroes.Where(a => a.Nom.Contains(filtre)));
                    this.ManagedList = new ObservableCollection<DBItem>(ListMacros);
                    break;
                case DBItemType.Meta:
                    this.ListMetas = new ObservableCollection<Meta>(
                    App.Entities.Metas.Where(a => a.Nom.Contains(filtre)));
                    this.ManagedList = new ObservableCollection<DBItem>(ListMetas);
                    break;
                case DBItemType.Environment:
                    this.ListEnvironments = new ObservableCollection<LTG_Entity.Environment>(
                    App.Entities.Environments.Where(a => a.Nom.Contains(filtre)));
                    this.ManagedList = new ObservableCollection<DBItem>(ListEnvironments);
                    break;
                default:
                    break;
            }
        }

        public RelayCommand CommandeNouveau { get; set; }
        public RelayCommand CommandeEffacer { get; set; }
        public RelayCommand CommandeGenerer { get; set; }
        public RelayCommand CommandeSauver { get; set; }
        
        public RelayCommand BoutonPackages { get; set; }
        public RelayCommand BoutonMacros { get; set; }
        public RelayCommand BoutonEnvironments { get; set; }
        public RelayCommand BoutonMetas { get; set; }


        private void Sauver()
        {
            //foreach (DbEntityEntry entry in App.Entities.ChangeTracker.Entries())
            //{
            //    Console.WriteLine(entry.State);
            //}

            try
            {
                SaveDB();
                _dialogCoordinator.ShowMessageAsync(this, "Information", "les articles ont été sauvés");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }

        private void SaveDB()
        {
            foreach (Template x in ListTemplates)
            {
                if (x.Id == -1)
                {
                    App.Entities.Templates.Add(x);
                }
            }
            foreach (Macro x in ListMacros)
            {
                if (x.Id == -1)
                {
                    App.Entities.Macroes.Add(x);
                }
            }
            foreach (Meta x in ListMetas)
            {
                if (x.Id == -1)
                {
                    App.Entities.Metas.Add(x);
                }
            }
            foreach (LTG_Entity.Environment x in ListEnvironments)
            {
                if (x.Id == -1)
                {
                    App.Entities.Environments.Add(x);
                }
            }

            try
            {
                App.Entities.SaveChanges();
                //
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _dialogCoordinator.ShowMessageAsync(this, "Information", "Un problème est survenu lors de la sauvegarde!");
                throw;
            }



            Init();
        }

        private void Nouveau()
        {
            int i = 1;
            string originalName = "";
            switch (CurrentType)
            {
                case DBItemType.Template:
                    ManagedItem = Template.NewTemplate();
                    originalName = ManagedItem.Name;
                    while (true)
                    {
                        if (ListTemplates.Any(t => t.Nom == ManagedItem.Name) || ListTemplates.Any(t => t.Nom == ManagedItem.Name + " (" + i + ")"))
                        {
                            ((Template)ManagedItem).Nom = originalName + " (" + i + ")";
                            i++;
                        }
                        else
                            break;
                    }
                    FirePropertyChanged("ManagedItem");
                    ListTemplates.Add((Template)ManagedItem);
                    break;
                case DBItemType.Macro:
                    ManagedItem = Macro.newMacro();
                    originalName = ManagedItem.Name;
                    while (true)
                    {
                        if (ListMacros.Any(t => t.Nom == ManagedItem.Name) || ListMacros.Any(t => t.Nom == ManagedItem.Name + " (" + i + ")"))
                        {
                            ((Macro)ManagedItem).Nom = originalName + " (" + i + ")";
                            i++;
                        }
                        else
                            break;
                    }
                    ListMacros.Add((Macro)ManagedItem);
                    break;
                case DBItemType.Meta:
                    ManagedItem = Meta.newMeta();
                    originalName = ManagedItem.Name;
                    while (true)
                    {
                        if (ListMetas.Any(t => t.Nom == ManagedItem.Name) || ListMetas.Any(t => t.Nom == ManagedItem.Name + " (" + i + ")"))
                        {
                            ((Meta)ManagedItem).Nom = originalName + " (" + i + ")";
                            i++;
                        }
                        else
                            break;
                    }
                    ListMetas.Add((Meta)ManagedItem);
                    break;
                case DBItemType.Environment:
                    ManagedItem = LTG_Entity.Environment.newEnvironment();
                    originalName = ManagedItem.Name;
                    while (true)
                    {
                        if (ListEnvironments.Any(t => t.Nom == ManagedItem.Name) || ListEnvironments.Any(t => t.Nom == ManagedItem.Name + " (" + i + ")"))
                        {
                            ((LTG_Entity.Environment)ManagedItem).Nom = originalName + " (" + i + ")";
                            i++;
                        }
                        else
                            break;
                    }
                    ListEnvironments.Add((LTG_Entity.Environment)ManagedItem);
                    break;
                default:
                    break;
            }

            ManagedList.Add(ManagedItem);

            try
            {
                SaveDB();
                //_dialogCoordinator.ShowMessageAsync(this, "Information", "les articles ont été sauvés");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _dialogCoordinator.ShowMessageAsync(this, "Erreur", "Le nouvel élément n'a pas pu être créé");
            }

            //ArticleCourant = Article.NouvelArticle();
            //ListeArticles.Add(ArticleCourant);

        }
        private void Effacer()
        {
            string type = "";

            switch (CurrentType)
            {
                case DBItemType.Template:
                    type = "le template";
                    break;
                case DBItemType.Macro:
                    type = "la macro";
                    break;
                case DBItemType.Meta:
                    type = "le meta";
                    break;
                case DBItemType.Environment:
                    type = "l'environment";
                    break;
                default:
                    break;
            }

            MessageBoxResult effacer = MessageBox.Show(string.Format("Êtes-vous sûr de vouloir effacer {0} \"{1}\" ?", type, ManagedItem.Name), "Fermeture", MessageBoxButton.OKCancel);

            if (effacer == MessageBoxResult.OK)
            {
                switch (CurrentType)
                {
                    case DBItemType.Template:
                        Effacer((Template)ManagedItem);
                        break;
                    case DBItemType.Macro:
                        Effacer((Macro)ManagedItem);
                        break;
                    case DBItemType.Meta:
                        Effacer((Meta)ManagedItem);
                        break;
                    case DBItemType.Environment:
                        Effacer((LTG_Entity.Environment)ManagedItem);
                        break;
                    default:
                        break;
                }
                try
                {
                    SaveDB();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _dialogCoordinator.ShowMessageAsync(this, "Erreur", "Le nouvel élément n'a pas pu être effacé");
                }
               
            }
           
        }
        private void Effacer(Template t)
        {
            // Delete all dependencies first
            foreach (TemplatePackage tp in App.Entities.TemplatePackages)
            {
                if (tp.Template.Nom == t.Name)
                {
                    App.Entities.TemplatePackages.Remove(tp);
                }
            }
            foreach (TemplateMeta tp in App.Entities.TemplateMetas)
            {
                if (tp.Template.Nom == t.Name)
                {
                    App.Entities.TemplateMetas.Remove(tp);
                }
            }
            foreach (TemplateMacro tp in App.Entities.TemplateMacroes)
            {
                if (tp.Template.Nom == t.Name)
                {
                    App.Entities.TemplateMacroes.Remove(tp);
                }
            }
            foreach (TemplateEnvironment tp in App.Entities.TemplateEnvironments)
            {
                if (tp.Template.Nom == t.Name)
                {
                    App.Entities.TemplateEnvironments.Remove(tp);
                }
            }

            // Then remove from list
            Template tempToRemove = ListTemplates.FirstOrDefault(a => a.Nom == t.Name);
            ListTemplates.Remove(tempToRemove);
            ManagedList.Remove(tempToRemove);

            // And remove from DB
            App.Entities.Templates.Remove(App.Entities.Templates.FirstOrDefault(a => a.Nom == t.Name));
        }
        private void Effacer(Macro m)
        {
            Macro macroToRemove = ListMacros.FirstOrDefault(a => a.Nom == m.Name);
            ListMacros.Remove(macroToRemove);
            ManagedList.Remove(macroToRemove);
            App.Entities.Macroes.Remove(m);
        }
        private void Effacer(Meta m)
        {
            Meta metaToRemove = ListMetas.FirstOrDefault(a => a.Nom == m.Name);
            ListMetas.Remove(metaToRemove);
            ManagedList.Remove(metaToRemove);
            App.Entities.Metas.Remove(m);
        }
        private void Effacer(LTG_Entity.Environment e)
        {
            LTG_Entity.Environment envToRemove = ListEnvironments.FirstOrDefault(a => a.Nom == e.Name);
            ListEnvironments.Remove(envToRemove);
            ManagedList.Remove(envToRemove);
            App.Entities.Environments.Remove(e);
        }
        private void CreateWindowGenerate()
        {
            // Crée fenêtre de génération du code

            // D'abord, créer object qui gère le content complet du template courant
            Helpers.TemplateContent tc = new Helpers.TemplateContent(currentTemplate());
            // Ensuite créer l'object qui formatte le code sur la base du content
            TemplateFormatter tf = new TemplateFormatter(tc);

            // Ensuite créer la fenêtre avec code généré
            WindowGeneratedCode gc = new WindowGeneratedCode();
            gc.Code.Text = tf.generate();
            gc.Show();
        }



        private Template currentTemplate()
        {
            foreach (Template t in ListTemplates)
            {
                if (ManagedItem != null)
                {
                    if (t.Nom == ManagedItem.Name)
                        return t;
                }
            }
            Console.WriteLine("Error, no template found!");
            return null;
        }
        private Macro currentMacro()
        {
            foreach (Macro m in ListMacros)
            {
                if (ManagedItem != null)
                {
                    if (m.Nom == ManagedItem.Name)
                        return m;
                }
            }
            Console.WriteLine("Error, no macro found!");
            return null;
        }
        private LTG_Entity.Environment currentEnvironment()
        {
            foreach (LTG_Entity.Environment e in ListEnvironments)
            {
                if (ManagedItem != null)
                {
                    if (e.Nom == ManagedItem.Name)
                        return e;
                }
            }
            Console.WriteLine("Error, no macro found!");
            return null;
        }
        private Meta currentMeta()
        {
            foreach (Meta m in ListMetas)
            {
                if (ManagedItem != null)
                {
                    if (m.Nom == ManagedItem.Name)
                        return m;
                }
            }
            Console.WriteLine("Error, no macro found!");
            return null;
        }


        private void BtnPackages()
        {
            PManageDependencies ManageDependenciesWindow = new PManageDependencies();
            ManageDependenciesWindow.Title = "Manage Packages";
            switch (CurrentType)
            {
                case DBItemType.Template:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Package, currentTemplate());
                    break;
                case DBItemType.Macro:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Package, currentMacro());
                    break;
                case DBItemType.Meta:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Package, currentMeta());
                    break;
                case DBItemType.Environment:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Package, currentEnvironment());
                    break;
                default:
                    break;
            }
            
            ManageDependenciesWindow.Show();
        }

        private void BtnMacros()
        {
            PManageDependencies ManageDependenciesWindow = new PManageDependencies();
            ManageDependenciesWindow.Title = "Manage Macros";
            switch (CurrentType)
            {
                case DBItemType.Template:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Macro, currentTemplate());
                    break;
                case DBItemType.Meta:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Macro, currentMeta());
                    break;
                default:
                    break;
            }
            
            ManageDependenciesWindow.Show();
        }

        private void BtnMetas()
        {
            PManageDependencies ManageDependenciesWindow = new PManageDependencies();
            ManageDependenciesWindow.Title = "Manage Meta-packages";
            switch (CurrentType)
            {
                case DBItemType.Template:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Meta, currentTemplate());
                    break;
                case DBItemType.Meta:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Meta, currentMeta());
                    break;
                default:
                    break;
            }

            
            ManageDependenciesWindow.Show();
        }

        private void BtnEnvs()
        {
            PManageDependencies ManageDependenciesWindow = new PManageDependencies();
            ManageDependenciesWindow.Title = "Manage Environments";
            switch (CurrentType)
            {
                case DBItemType.Template:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Environment, currentTemplate());
                    break;
                case DBItemType.Meta:
                    ManageDependenciesWindow.DataContext = new VMDependencyManagment(DBItemType.Environment, currentMeta());
                    break;
                default:
                    break;
            }
            ManageDependenciesWindow.ShowDialog();
        }


        public bool HasItem
        {
            get { return ManagedItem != null; }
        }

        public bool HasManagedList
        {
            get { return ManagedList != null; }
        }



    }
}

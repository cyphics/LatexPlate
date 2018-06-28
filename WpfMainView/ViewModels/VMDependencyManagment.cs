using GalaSoft.MvvmLight.CommandWpf;
using LTG_Entity;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMainView.Helpers;
using static WpfMainView.Controls.UCListDisplaySearch;
using static WpfMainView.Helpers.VMHelper;

namespace WpfMainView.ViewModels
{
    class VMDependencyManagment : VMBaseViewModel
    {
        private IDialogCoordinator _dialogCoordinator = DialogCoordinator.Instance;
        // Properties
        public DBItemType DependencyType { get; set; }
        public DBItemType ManagedItemType { get; set; }
        private ObservableCollection<DBItem> _listAvailables;
        public ObservableCollection<DBItem> ListAvailables
        {
            get { return _listAvailables; }
            set { _listAvailables = value;
                
                FirePropertyChanged();
            }
        }
        private ObservableCollection<DBItem> _listDependencies;
        public ObservableCollection<DBItem> ListDependencies
        {
            get { return _listDependencies; }
            set { _listDependencies = value;
                FirePropertyChanged();
            }
        }
        
        private DBItem _current;
        public DBItem CurrentDep
        {
            get { return _currentDep; }
            set
            {

                _currentDep = value;
                if (_currentDep != null)
                {
                    switch (DependencyType)
                    {
                        case DBItemType.Template:
                            break;
                        case DBItemType.Macro:
                            DepName = ((Macro)CurrentDep).Name;
                            break;
                        case DBItemType.Package:
                            DepName = ((Package)CurrentDep).Name;
                            break;
                        case DBItemType.Meta:
                            DepName = ((Meta)CurrentDep).Name;
                            break;
                        case DBItemType.Environment:
                            DepName = ((LTG_Entity.Environment)CurrentDep).Name;
                            break;
                        default:
                            break;
                    }
                }

                FirePropertyChanged();
            }
        }
        public DBItem CurrentAvailable
        {
            get { return _current; }
            set
            {
                _current = value;

                FirePropertyChanged();
            }
        }
        private DBItem _currentDep;
        private string _depName;
        public string DepName
        {
            get { return _depName; }
            set
            {
                _depName = value;
                FirePropertyChanged();
            }
        }
        public Template ManagedTemplate { get; set; }
        public Macro ManagedMacro { get; set; }
        public Meta ManagedMeta { get; set; }
        public LTG_Entity.Environment ManagedEnvironment { get; set; }

        // Constructors
        public VMDependencyManagment(DBItemType type_available, Template t)
        {
            ManagedTemplate = t;
            ManagedItemType = DBItemType.Template;
            ListDependencies = Linq.DependenciesList(t, type_available);
            Init(type_available);
        }
        public VMDependencyManagment(DBItemType type_available, Macro current)
        {
            ManagedMacro = current;
            ManagedItemType = DBItemType.Macro;
            ListDependencies = Linq.DependenciesList(current, type_available);
            Init(type_available);
        }
        public VMDependencyManagment(DBItemType type_available, LTG_Entity.Environment current)
        {
            ManagedEnvironment = current;
            ManagedItemType = DBItemType.Environment;
            ListDependencies = Linq.DependenciesList(current, type_available);
            Init(type_available);
        }
        public VMDependencyManagment(DBItemType type_available, Meta current)
        {
            ManagedMeta = current;
            ManagedItemType = DBItemType.Meta;
            ListDependencies = Linq.DependenciesList(current, type_available);
            Init(type_available);
        }
        private void Init(DBItemType type)
        {
            ListAvailables = VMHelper.SetListFromType(type);
            DependencyType = type;
            CommandeAjouter = new RelayCommand(btn_Ajouter);
            CommandeRetirer = new RelayCommand(btn_Retirer);
        }

        public RelayCommand CommandeAjouter { get; set; }
        public RelayCommand CommandeRetirer { get; set; }

        public void btn_Ajouter()
        {
            if (CurrentAvailable != null)
            {
                // Si la dep n'est pas déjà présente
                if (! ListDependencies.Contains(CurrentAvailable))
                {
                    ListDependencies.Add(CurrentAvailable);

                    // Which item are we managing dependencies for
                    switch (ManagedItemType)
                    {
                        case DBItemType.Template:
                            // What dependency type
                            switch (DependencyType)
                            {
                                case DBItemType.Macro:
                                    App.Entities.TemplateMacroes.Add(TemplateMacro.newTemplateMacro(ManagedTemplate, (Macro)CurrentAvailable));
                                    break;
                                case DBItemType.Package:
                                    App.Entities.TemplatePackages.Add(TemplatePackage.newTemplatePackage(ManagedTemplate, (Package)CurrentAvailable));
                                    break;
                                case DBItemType.Meta:
                                    App.Entities.TemplateMetas.Add(TemplateMeta.newTemplateMeta(ManagedTemplate, (Meta)CurrentAvailable));
                                    break;
                                case DBItemType.Environment:
                                    App.Entities.TemplateEnvironments.Add(TemplateEnvironment.newTemplateEnvironment(ManagedTemplate, (LTG_Entity.Environment)CurrentAvailable));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case DBItemType.Macro:
                            ManagedMacro.Packages.Add((Package)CurrentAvailable);
                            break;
                        case DBItemType.Meta:
                            switch (DependencyType)
                            {
                                case DBItemType.Macro:
                                    ManagedMeta.Macroes.Add((Macro)CurrentAvailable);
                                    break;
                                case DBItemType.Package:
                                    ManagedMeta.Packages.Add((Package)CurrentAvailable);
                                    break;
                                case DBItemType.Meta:
                                    ManagedMeta.Metas.Add((Meta)CurrentAvailable);
                                    break;
                                case DBItemType.Environment:
                                    ManagedMeta.Environments.Add((LTG_Entity.Environment)CurrentAvailable);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case DBItemType.Environment:
                            ManagedEnvironment.Packages.Add((Package)CurrentAvailable);
                            break;
                        default:
                            break;
                    }
                }

                try
                {
                    App.Entities.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _dialogCoordinator.ShowMessageAsync(this, "Information", "Un problème est survenu lors de l'ajout");
                    
                }
                
                
                
            }
        }
        public void btn_Retirer()
        {
            if (CurrentDep != null)
            {
                ListDependencies.Remove(CurrentDep);
                Package currentPackage = null;
                Macro currentMacro = null;
                LTG_Entity.Environment currentEnv = null;
                Meta currentMeta = null;
                switch (ManagedItemType)
                {
                    case DBItemType.Template:
                        switch (DependencyType)
                        {
                            case DBItemType.Macro:
                                 currentMacro = (Macro)ListAvailables.FirstOrDefault(p => ((Macro)p).Name == DepName);
                                Linq.RemoveJoin(ManagedTemplate, currentMacro);
                                break;
                            case DBItemType.Package:
                                currentPackage = (Package)ListAvailables.FirstOrDefault(p => ((Package)p).Name == DepName);
                                Linq.RemoveJoin(ManagedTemplate, currentPackage);
                                break;
                            case DBItemType.Meta:
                                currentMeta = (Meta)ListAvailables.FirstOrDefault(p => ((Meta)p).Name == DepName);
                                Linq.RemoveJoin(ManagedTemplate, currentMeta);
                                break;
                            case DBItemType.Environment:
                                currentEnv = (LTG_Entity.Environment)ListAvailables.FirstOrDefault(p => ((LTG_Entity.Environment)p).Name == DepName);
                                Linq.RemoveJoin(ManagedTemplate, currentEnv);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DBItemType.Macro:
                        currentPackage = (Package)ListAvailables.FirstOrDefault(p => ((Package)p).Name == DepName);
                        ManagedMacro.Packages.Remove(currentPackage);
                        break;
                    case DBItemType.Meta:
                        switch (DependencyType)
                        {
                            case DBItemType.Macro:
                                currentMacro = (Macro)ListAvailables.FirstOrDefault(p => ((Macro)p).Name == DepName);
                                ManagedMeta.Macroes.Remove(currentMacro);
                                break;
                            case DBItemType.Package:
                                currentPackage = (Package)ListAvailables.FirstOrDefault(p => ((Package)p).Name == DepName);
                                ManagedMeta.Packages.Remove(currentPackage);
                                break;
                            case DBItemType.Meta:
                                currentMeta = (Meta)ListAvailables.FirstOrDefault(p => ((Meta)p).Name == DepName);
                                ManagedMeta.Metas.Remove(currentMeta);
                                break;
                            case DBItemType.Environment:
                                currentEnv = (LTG_Entity.Environment)ListAvailables.FirstOrDefault(p => ((LTG_Entity.Environment)p).Name == DepName);
                                ManagedMeta.Environments.Remove(currentEnv);
                                break;
                            default:
                                break;
                        }

                        break;
                    case DBItemType.Environment:
                        currentPackage = (Package)ListAvailables.FirstOrDefault(p => ((Package)p).Name == DepName);
                        ManagedEnvironment.Packages.Remove(currentPackage);
                        break;
                    default:
                        break;
                }
                
            }
            
            App.Entities.SaveChanges();
        }

        public void FiltrerListe(string filtre)
        {
            switch (DependencyType)
            {
                case DBItemType.Macro:
                    this.ListAvailables = new ObservableCollection<DBItem>(
                   App.Entities.Macroes.Where(a => a.Nom.Contains(filtre)));
                    break;
                case DBItemType.Meta:
                    this.ListAvailables = new ObservableCollection<DBItem>(
                   App.Entities.Metas.Where(a => a.Nom.Contains(filtre)));
                    break;
                case DBItemType.Environment:
                    break;
                case DBItemType.Package:
                    this.ListAvailables = new ObservableCollection<DBItem>(
                    App.Entities.Packages.Where(a => a.Nom.Contains(filtre)));
                    break;
                default:
                    break;


            }
        }
    }



}

using GalaSoft.MvvmLight.CommandWpf;
using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfMainView.Helpers;

namespace WpfMainView.ViewModels
{
    class VMScanPackages : VMBaseViewModel
    {
        private ObservableCollection<Package> _listPackages;

        public ObservableCollection<Package> ListPackages
        {
            get { return _listPackages; }
            set { _listPackages = value; }
            
        }
        
        private ObservableCollection<ScanDir> _listDirs;

        public ObservableCollection<ScanDir> ListDirectories
        {
            get { return _listDirs; }
            set { _listDirs = value;
                FirePropertyChanged();
            }
        }

        private ScanDir _currentDir;

        public ScanDir CurrentDir
        {
            get { return _currentDir; }
            set { _currentDir = value; }
        }


        public RelayCommand CommandScan { get; set; }
        public RelayCommand  CommandAddDirectory { get; set; }
        public RelayCommand CommandRemoveDirectory { get; set; }
        public RelayCommand CommandPurge { get; set; }
        public RelayCommand CommandSave { get; set; }


        public VMScanPackages() {
            ListDirectories = new ObservableCollection<ScanDir>(App.Entities.ScanDirs);
            ListPackages = new ObservableCollection<Package>(App.Entities.Packages);
            CommandScan = new RelayCommand(Scan);
            CommandPurge = new RelayCommand(Purge);
            CommandAddDirectory = new RelayCommand(AddDirectory);
            CommandRemoveDirectory = new RelayCommand(RemoveDirectory);
            CommandSave = new RelayCommand(SaveDB);
        }

        private void Scan()
        {
            int addedpackages = 0;
            int foundpackages = 0;
            Console.WriteLine("Scan initialisé...");
            List<Package> AllPackages = new List<Package>();

            foreach (ScanDir path in ListDirectories)
            {
                HashSet<string> newPackageNames = new HashSet<string>(PackageScan.StyFromDir((path.Path)));
                foreach (string packageName in newPackageNames)
                {
                    Package newPackage = Package.newPackage();
                    newPackage.Nom = packageName;
                    AllPackages.Add(newPackage);
                }
            }

            foreach (Package newPackage in AllPackages)
            {
                foundpackages++;
                if (! ListPackages.Any(p => p.Nom == newPackage.Nom))
                {
                    Console.WriteLine("Adding package " + newPackage.Nom);
                    ListPackages.Add(newPackage);
                    addedpackages++;
                }
            }
            Console.WriteLine("Scan terminé.\n" + foundpackages + " packages trouvés.\n" + addedpackages + " packages ajoutés");
            SaveDB();
        }

        private void Purge()
        {
            //foreach (Package package in ListPackages)
            //{
            //    App.Entities.Packages.Remove(App.Entities.Packages.FirstOrDefault(p => p.Nom == package.Nom));
            //    try
            //    {
            //        App.Entities.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            //App.Entities.Packages.


            var packages = from o in App.Entities.Packages
                           select o;
            foreach (var  package in packages)
            {
                App.Entities.Packages.Remove(package);
            }

            App.Entities.SaveChanges();


            ListPackages = new ObservableCollection<Package>(App.Entities.Packages);
        }

        private void AddDirectory()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    bool addDir = true;
                    foreach (ScanDir sc in ListDirectories)
                    {
                        if (sc.Path == fbd.SelectedPath)
                        {
                            addDir = false;
                        }
                    }

                    if (addDir)
                    {
                        ScanDir sc = ScanDir.newScanDir();
                        sc.Path = fbd.SelectedPath;
                        ListDirectories.Add(sc);
                    }
                }
            }
        }

        private void RemoveDirectory()
        {
            foreach (ScanDir sd in App.Entities.ScanDirs)
            {
                if (sd.Path == CurrentDir.Path)
                {
                    App.Entities.ScanDirs.Remove(sd);
                    
                }
            }
            ListDirectories.Remove(ListDirectories.FirstOrDefault(d => d.Path == CurrentDir.Path));
        }

        private void SaveDB()
        {
            foreach (ScanDir sc in ListDirectories)
            {
                if (sc.Id == -1)
                {
                    App.Entities.ScanDirs.Add(sc);
                }
            }

            foreach (Package package in ListPackages)
            {
                if (package.Id == -1)
                {
                    Console.WriteLine("Adding " + package.Nom  + " to the DB");
                    App.Entities.Packages.Add(package);
                }

            }

            try
            {
                App.Entities.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }

        
    }
}

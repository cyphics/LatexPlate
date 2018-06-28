using LTG_Entity;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfMainView.Controls.UCListDisplaySearch;

namespace WpfMainView.ViewModels
{
    class VMListDisplaySearch : VMBaseViewModel
    {
        private IDialogCoordinator _dialogCoordinator = DialogCoordinator.Instance;

        //private LTGEntities _entity = new LTGEntities();

        private ObservableCollection<DBItem> _liste;

        public ObservableCollection<DBItem> CurrentDisplayedList
        {
            get { return _liste; }
            set {
                _liste = value;
                FirePropertyChanged();
            }
        }

        private DBItem _current;

        public DBItem SelectedItem
        {
            get { return _current; }
            set
            {
                _current = value;
                FirePropertyChanged();
            }
        }


        //selon la classe envoyé, on génère une liste d'enregistrements
        public VMListDisplaySearch(DBItem currentItem)
        {
            
            SelectedItem = currentItem;
        }
    }

}

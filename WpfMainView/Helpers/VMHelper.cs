using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfMainView.Controls.UCListDisplaySearch;

namespace WpfMainView.Helpers
{
    public class VMHelper
    {
        public enum DBItemType
        {
            Template,
            Macro,
            Package,
            Meta,
            Environment
        };

        public static ObservableCollection<DBItem> SetListFromType (DBItemType type)
        {
            // Return the list of Objects in DB according to DBItemType

            ObservableCollection<DBItem> Liste = null;

            switch (type)
            {
                case DBItemType.Template:
                    Liste = new ObservableCollection<DBItem>(App.Entities.Templates);
                    break;
                case DBItemType.Macro:
                    Liste = new ObservableCollection<DBItem>(App.Entities.Macroes);
                    break;
                case DBItemType.Package:
                    Liste = new ObservableCollection<DBItem>(App.Entities.Packages);
                    break;
                case DBItemType.Meta:
                    Liste = new ObservableCollection<DBItem>(App.Entities.Metas);
                    break;
                case DBItemType.Environment:
                    Liste = new ObservableCollection<DBItem>(App.Entities.Environments);
                    break;
                default:
                    break;
            }

            return Liste;
        }

    }
}

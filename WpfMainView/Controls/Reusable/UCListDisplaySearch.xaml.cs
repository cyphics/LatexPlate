using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMainView.ViewModels;
using static WpfMainView.Helpers.VMHelper;
using static WpfMainView.ViewModels.VMListDisplaySearch;

namespace WpfMainView.Controls
{
    
    /// <summary>
    /// Interaction logic for ListDisplaySearch.xaml
    /// </summary>
    public partial class UCListDisplaySearch : UserControl
    {
        public UCListDisplaySearch()
        {
            InitializeComponent();
            //this.DataContext = new VMListDisplaySearch(DBItemType.Template);
            //VMListDisplaySearch vm = (VMListDisplaySearch)this.DataContext;
            //this.ListContainer.ItemsSource = vm.Liste;
        }

        public void SetName(string name)
        {
            ListName.Content = name;
        }

        private void SearchBox_KeyUp(object sender, RoutedEventArgs e)
        {
            string texteARechercher = SearchBox.textBoxRechercher.Text;
            VMManages mvm = (VMManages)this.DataContext;
            //mvm.FiltrerListeTemplates(texteARechercher);
        }



        

    }
}

using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static WpfMainView.Controls.UCListDisplaySearch;

namespace WpfMainView.Views
{
    /// <summary>
    /// Interaction logic for PManageDependencies.xaml
    /// </summary>
    public partial class PManageDependencies : Window
    {
        public PManageDependencies()
        {
            InitializeComponent();
        }


        private void ListAvailables_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ListDependencies.SelectedItem = null;


        }

        private void ListDependencies_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ListAvailables.SelectedItem = null;

        }

    }
}

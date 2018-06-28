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

namespace WpfMainView.Controls
{
    /// <summary>
    /// Interaction logic for UCMacros.xaml
    /// </summary>
    public partial class UCMacros : UserControl
    {
        public UCMacros()
        {
            InitializeComponent();
            //this.DataContext = new VMMacros();
        }

        private void btn_Packages_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Environments_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

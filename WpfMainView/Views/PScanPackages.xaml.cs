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
using System.Windows.Shapes;
using WpfMainView.ViewModels;

namespace WpfMainView.Views
{
    /// <summary>
    /// Logique d'interaction pour PackageManagment.xaml
    /// </summary>
    public partial class PScanPackages : Window
    {
        public PScanPackages()
        {
            InitializeComponent();
            this.DataContext = new VMScanPackages(); 
        }
    }
}

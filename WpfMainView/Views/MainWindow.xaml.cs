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
using MahApps.Metro.Controls;
using WpfMainView.Controls;
using WpfMainView.ViewModels;
using static WpfMainView.Controls.UCListDisplaySearch;
using static WpfMainView.ViewModels.VMListDisplaySearch;
using WpfMainView.Views;
using GalaSoft.MvvmLight.CommandWpf;
using static WpfMainView.Helpers.VMHelper;

namespace WpfMainView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // Declare changing parts of the IU
        //private UCTemplates _ucTemplates = new UCTemplates(); // default one
        //private UCMacros _ucMacros = null;
        //private UCMeta _ucMeta = null;
        //private UCEnvironments _ucEnv = null;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void menuTemplates_Click(object sender, RoutedEventArgs e) => UCManager.SetManager(DBItemType.Template);
        private void menuMacro_Click(object sender, RoutedEventArgs e) => this.UCManager.SetManager(DBItemType.Macro);
        private void menuMeta_Click(object sender, RoutedEventArgs e) => this.UCManager.SetManager(DBItemType.Meta);
        private void menuEnv_Click(object sender, RoutedEventArgs e) => this.UCManager.SetManager(DBItemType.Environment);

        private void menuClose_Click(object sender, RoutedEventArgs e) => this.Close();

        private void mnu_Scan_Click(object sender, RoutedEventArgs e)
        {
            PScanPackages scanWindow = new PScanPackages();
            scanWindow.Show();
        }


    }
}

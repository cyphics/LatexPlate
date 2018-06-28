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
    /// Interaction logic for UCTemplates.xaml
    /// </summary>
    public partial class UCMeta : UserControl
    {
        public UCMeta()
        {
            InitializeComponent();
            //this.DataContext = new VMMetas();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

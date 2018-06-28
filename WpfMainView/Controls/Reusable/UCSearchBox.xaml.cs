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
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class UCSearchBox : UserControl
    {
        public UCSearchBox()
        {
            InitializeComponent();
        }

        private void textBoxRechercher_KeyUp(object sender, KeyEventArgs e)
        {
            string texteARechercher = textBoxRechercher.Text;
            VMDependencyManagment vmd = null;
            VMManages vmm = null;

            try
            {
                vmd = (VMDependencyManagment)this.DataContext;
                vmd.FiltrerListe(texteARechercher);
            }
            catch (Exception error)
            {

                Console.WriteLine("Can't cast VMDependencyManagment datacontext in textBoxRechercher\n" +
                    error); ;
            }

            try
            {
                vmm = (VMManages)this.DataContext;
                vmm.FiltrerListe(texteARechercher);
            }
            catch (Exception e2)
            {

                Console.WriteLine("Can't cast VMManages datacontext in textBoxRechercher\n" + e2);
            }
            
        }
    }
}

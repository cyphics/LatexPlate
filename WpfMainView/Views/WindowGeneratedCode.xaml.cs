using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfMainView.Views
{
    /// <summary>
    /// Interaction logic for GeneratedCode.xaml
    /// </summary>
    public partial class WindowGeneratedCode : Window
    {
        public WindowGeneratedCode()
        {
            InitializeComponent();
            
        }



        private void btn_Sauver_Click(object sender, RoutedEventArgs e)
        {

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "LaTeX files (*.tex)|*.tex|All files (*.*)|*.*";
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //if (sfd.ShowDialog().Equals(true))
            //{
            //    Console.WriteLine("SAVE");
            //        // Code to write the stream goes here.
            //        File.WriteAllText(sfd.FileName, "test");

            //}

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "template"; // Default file name
            dlg.DefaultExt = ".tex"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }

        private void btn_Copier_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(Code.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

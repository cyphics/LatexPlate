using LTG_Entity;
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
using static WpfMainView.Controls.UCListDisplaySearch;
using static WpfMainView.Helpers.VMHelper;
using static WpfMainView.ViewModels.VMListDisplaySearch;

namespace WpfMainView.Controls
{
    /// <summary>
    /// Interaction logic for UCManager.xaml
    /// </summary>
    public partial class UCManager : UserControl
    {
        
        private UCTemplates _ucTemplates = new UCTemplates(); // default one
        private UCMacros _ucMacros = null;
        private UCMeta _ucMeta = null;
        private UCEnvironments _ucEnv = null;

        


        public UCManager()
        {
            InitializeComponent();
            this.DataContext = new VMManages();
        }

        public void SetManager(DBItemType type)
        {
            TargetGrid.Children.Clear();
            ((VMManages)DataContext).ChangeManager(type);

            switch (type)
            {
                case DBItemType.Macro:
                    _ucMacros = new UCMacros();
                    TargetGrid.Children.Add(_ucMacros);

                    break;
                case DBItemType.Meta:
                    _ucMeta = new UCMeta();
                    TargetGrid.Children.Add(_ucMeta);
                    break;
                case DBItemType.Environment:
                    _ucEnv = new UCEnvironments();
                    TargetGrid.Children.Add(_ucEnv);
                    break;
                case DBItemType.Template:
                default:
                    _ucTemplates = new UCTemplates();
                    TargetGrid.Children.Add(_ucTemplates);
                    break;
            }
            // Send change to manager
            
        }




    }
}

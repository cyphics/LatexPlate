using LTG_Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMainView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
            private static LTGEntities _entities;

            public static LTGEntities Entities
            {
                get
                {
                    if (_entities is null) { _entities = new LTGEntities(); }
                    return _entities;
                }
            }
        
    }
}

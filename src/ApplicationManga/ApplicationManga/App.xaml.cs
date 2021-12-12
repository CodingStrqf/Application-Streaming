using Modele;
using Stub;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PersLINQXML;

namespace ApplicationManga
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager LeManager { get; set; } = new Manager(new Stub.Stub());//new PersXML

        public App()
        {
            LeManager.ChargeManga();
        }
    }
}

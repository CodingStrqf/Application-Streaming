using System;
using Modele;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationManga
{
    /// <summary>
    /// Logique d'interaction pour VideoEnPleinEcran.xaml
    /// </summary>
    public partial class VideoEnPleinEcran : UserControl
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public VideoEnPleinEcran()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void Fermer_Video(object sender, RoutedEventArgs e)
        {

        }
    }
}

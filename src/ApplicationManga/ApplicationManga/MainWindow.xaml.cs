using Modele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ApplicationManga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Manager Manager => (App.Current as App).LeManager;
        public MainWindow()
        {
            InitializeComponent();
            mComboBox3.ItemsSource = Enum.GetNames(typeof(Categories));
            FicheManga.Content = new UserControl1();
            VideoEnPleinEcran.Content = new VideoEnPleinEcran();
            DataContext = Manager;
            Manager.Persistance = new PersLINQXML.PersXML();
            Manager.ListeDeManga.RemplissageAff(Manager.ListeDeManga.ListManga);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MangaSelectionnee = null;
            Window1 fenetre = new Window1();
            fenetre.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mComboBox3.SelectedIndex == 0)
            {   
                Manager.ListeDeManga.Creation();
            }

            if (mComboBox3.SelectedIndex == 1)
            {
                Manager.ListeDeManga.AjouterCategorie(Categories.Shonen);
            }

            if(mComboBox3.SelectedIndex == 2)
            {
                Manager.ListeDeManga.AjouterCategorie(Categories.Horreur);
            }

            if (mComboBox3.SelectedIndex == 3)
            {
                Manager.ListeDeManga.AjouterCategorie(Categories.Psychologie);
            }

            if (mComboBox3.SelectedIndex == 4)
            {
                Manager.ListeDeManga.AjouterCategorie(Categories.Action);
            }

            if (mComboBox3.SelectedIndex == 5)
            {
                Manager.ListeDeManga.AjouterCategorie(Categories.Sport);
            }
            FicheManga.Visibility = Visibility.Collapsed;
        }

        // ouverture d'une fiche de manga
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FicheManga.Visibility = Visibility.Visible;
            FicheManga.Content = new UserControl1();
            Manager.LesLike();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.ListeDeManga.AjouterCategorie(Categories.Shonen);
        }

        private void Rech_Click(object sender, MouseButtonEventArgs e)
        {
            Manager.Text = "";
            FicheManga.Visibility = Visibility.Collapsed;
        }
        // ouverture d'une fiche de manga FIN

        // boutton en cours
        private void ListeEnCoursXAML_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Manager.MangaSelectionneeEncour != null)
            {
                Manager.MangaSelectionneeEncour.ProchainEpisode.Ouverture();
                Manager.ListeDeManga.ProchainEpisode(Manager.MangaSelectionneeEncour, Manager.MangaSelectionneeEncour.ProchainEpisode);
            }
            Manager.SauvegardeDonnees();
        }
        // boutton en cours FIN
    }
}

using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApplicationManga
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public Window1()
        {
            InitializeComponent();
            mComboBox3.ItemsSource = Enum.GetNames(typeof(Categories));
            contentControl.Content = new UserControl1();
            DataContext = Mgr;
            Mgr.ListeDeManga.RemplissageAff(Mgr.ListeDeManga.ListFavories);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetre = new MainWindow();
            Mgr.MangaSelectionnee = null;
            fenetre.Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contentControl.Visibility = Visibility.Visible;
            contentControl.Content = new UserControl1();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mComboBox3.SelectedIndex == 0)
            {       
                Mgr.ListeDeManga.CreationFav();
            }

            if (mComboBox3.SelectedIndex == 1)
            {
                Mgr.ListeDeManga.AjouterCategorieFav(Categories.Shonen);
            }

            if (mComboBox3.SelectedIndex == 2)
            {
                Mgr.ListeDeManga.AjouterCategorieFav(Categories.Horreur);
            }

            if (mComboBox3.SelectedIndex == 3)
            {
                Mgr.ListeDeManga.AjouterCategorieFav(Categories.Psychologie);
            }

            if (mComboBox3.SelectedIndex == 4)
            {
                Mgr.ListeDeManga.AjouterCategorieFav(Categories.Action);
            }

            if (mComboBox3.SelectedIndex == 5)
            {         
                Mgr.ListeDeManga.AjouterCategorieFav(Categories.Sport);
            }
            contentControl.Visibility = Visibility.Collapsed;
        }

        private void Rech_Click(object sender, MouseButtonEventArgs e)
        {
            Mgr.Text2 = "";
            contentControl.Visibility = Visibility.Collapsed;
        }
    }
}

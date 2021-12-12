using Modele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public Manager Mgr => (App.Current as App).LeManager;

        public UserControl1()
        {
            InitializeComponent();
            DataContext = Mgr;
            Couleur();
        }

        // Favories //
        private void Couleur()
        {
            if(Mgr.MangaSelectionnee != null)
            {
                if (Mgr.MangaSelectionnee.Favoris)
                {
                    FavCoeur.Background = Brushes.Red;
                }
                else
                {
                    FavCoeur.Background = Brushes.Transparent;
                }

                if(Mgr.MangaSelectionnee.Notes.Count == 2)
                {
                    Like.Background = Brushes.Blue;
                }
                else
                {
                    Like.Background = Brushes.Transparent;
                }
            }
            
        }
        
        private void ButtonFav(object sender, RoutedEventArgs e)
        {
            if (Mgr.MangaSelectionnee.Favoris)
            {
                Mgr.ListeDeManga.SupprimerFav(Mgr.MangaSelectionnee);
            }
            else
            {
                Mgr.ListeDeManga.AjouterFav(Mgr.MangaSelectionnee);
            }
            Couleur();
            Mgr.SauvegardeDonnees();
        }


        // Favories FIN //

        private void ButtonLike(object sender, RoutedEventArgs e)
        {
            if(Mgr.MangaSelectionnee.Notes.Count == 2)
            {
                Mgr.MangaSelectionnee.Notes.Remove(Mgr.MangaSelectionnee.Notes.Last) ;
            }
            else
            {
                Mgr.MangaSelectionnee.Notes.AddLast(new Note(1));
            }
            Couleur();
            Mgr.SauvegardeDonnees();

        }

        // EPISODES //

        private void BoutonEp(object sender, SelectionChangedEventArgs e)
        {
            if(Mgr.EpSelectionnee != null)
            {
                if (!Mgr.ListeDeManga.ListEncour.Contains(Mgr.MangaSelectionnee))
                {
                    Mgr.ListeDeManga.AjouterEncour(Mgr.MangaSelectionnee);
                }

                Mgr.EpSelectionnee.Ouverture();

                Mgr.ListeDeManga.ProchainEpisode(Mgr.MangaSelectionnee, Mgr.EpSelectionnee);
            }
            Mgr.SauvegardeDonnees();

        }

        // FIN EPISODES //

        // BANDE ANNONCE //
        private void Video(object sender, RoutedEventArgs e)
        {
            Video fenetre = new Video();
            fenetre.Show();
        }

        private void Button_MouseEnter_Video(object sender, MouseEventArgs e)
        {
            mediaVideo.Visibility = Visibility.Visible;
            mediaVideo.LoadedBehavior = MediaState.Play;
            imagePresentation.Visibility = Visibility.Collapsed;
        }

        private void Button_MouseLeave_Video(object sender, MouseEventArgs e)
        {
            mediaVideo.Visibility = Visibility.Collapsed;
            mediaVideo.LoadedBehavior = MediaState.Stop;
            imagePresentation.Visibility = Visibility.Visible;
        }

        // FIN BANDE ANNONCE //

        private void Auteur_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Auteur.Text == "Auteur")
            { 
                Auteur.Text = "";
                Auteur.Foreground = Brushes.Black;
            }
        }

        private void Auteur_MouseLeave(object sender, MouseEventArgs e)
        {
            if(Auteur.Text == "")
            {
                Auteur.Text = "Auteur";
                Auteur.Foreground = Brushes.DarkGray;
            }
        }

        private void Commentaire_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Commentaire.Text == "Commentaire")
            {
                Commentaire.Text = "";
                Commentaire.Foreground = Brushes.Black;
            }
        }

        private void Commentaire_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Commentaire.Text == "")
            {
                Commentaire.Text = "Commentaire";
                Commentaire.Foreground = Brushes.DarkGray;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Auteur.Text == "Auteur" || Commentaire.Text == "Commentaire")
            {
                MessageBox.Show("Le champ Auteur ou Commentaire est vide", "Erreur", MessageBoxButton.OK);
                return;
            }            
            Commentaires com = new Commentaires(Auteur.Text,Commentaire.Text);
            Mgr.MangaSelectionnee.Commentaires.Add(com);
            Auteur.Text = "";
            Commentaire.Text = "";
        }

    }
}
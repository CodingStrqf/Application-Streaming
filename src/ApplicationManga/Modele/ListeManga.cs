using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;


namespace Modele
{
    public class ListeManga : INotifyPropertyChanged
    {
        /// <summary>
        /// List utiliser pour l'affichage 
        /// </summary>
        public ObservableCollection<Manga> ListAff 
        { 
            set
            {
                listAff = value;
                OnpropertyChange(nameof(ListAff));
            }
            get => listAff; 
        }
        private ObservableCollection<Manga> listAff = new ObservableCollection<Manga>();

        /// <summary>
        /// Liste de tous les mangas
        /// </summary>
        public List<Manga> ListManga { set; get; } = new List<Manga>();

        /// <summary>
        /// Liste des mangas favories
        /// </summary>
        public List<Manga> ListFavories { set; get; } = new List<Manga>();

        public event PropertyChangedEventHandler PropertyChanged;
        
        void OnpropertyChange(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Liste des mangas en cours 
        /// </summary>
        public ObservableCollection<Manga> ListEncour 
        {
            set 
            {
                listEncour = value;
                OnpropertyChange(nameof(ListEncour));
            }
            get => listEncour; 
        }

        private ObservableCollection<Manga> listEncour = new ObservableCollection<Manga>();

        /// <summary>
        /// Copie dans listAff les mangas contenu dans listManga
        /// </summary>
        public void CreationAff()
        {
            listAff = new ObservableCollection<Manga>();
            foreach (Manga m in ListManga)
            {
                ListAff.Add(m);
            }
        }

        // remplissage de liste aff
        public void RemplissageAff(List<Manga> l)
        {
            listAff = new ObservableCollection<Manga>();
            foreach (Manga m in l)
            {
                ListAff.Add(m);
            }
        }

        public void Creation()
        {
            listAff.Clear();
            foreach (Manga m in ListManga)
            {
                ListAff.Add(m);
            }
        }

        public void CreationFav()
        {
            listAff.Clear();
            foreach (Manga m in ListFavories)
            {
                ListAff.Add(m);
            }
        }

        /// <summary>
        /// Tri par catégorie de la ListeFavories 
        /// </summary>
        /// <param name="c">Categorie choisie</param>
        public void AjouterCategorieFav(Categories c)
        {
            listAff.Clear();
            foreach (Manga m in ListFavories)
            {
                if (m.Categorie == c)
                {
                    ListAff.Add(m);
                }
            }
        }

        /// <summary>
        /// Ajoute un manga à ListManga
        /// </summary>
        /// <param name="m1">Manga choisi</param>
        public void AjouterManga(Manga m1)
        {
            ListManga.Insert(ListManga.Count, m1);
            ListManga.Sort();
            return;
        }

        //partie Encour

        /// <summary>
        /// Ajoute un manga à ListEnCour
        /// </summary>
        /// <param name="m1">Manga choisi</param>
        public void AjouterEncour(Manga m1)
        {
            ListEncour.Add(m1);
            //ListEncour.Sort();
            return;
        }

        /// <summary>
        /// Episode en cours
        /// </summary>
        public void ProchainEpisode(Manga m, Episodes ep)
        {
            if (m.GetEpisodeCount() == m.GetEpisodeIndex(ep) + 1) // vérifi si c'est le dernier épisode pour l'enlever de encour
            {
                ListEncour.Remove(m);
            }
            else
            {
                m.ProchainEpisode = m.GetEpisodes(m.GetEpisodeIndex(ep) + 1);
            }
        }



        /// <summary>
        /// Tri par catégorie de la ListManga 
        /// </summary>
        /// <param name="c">Categorie choisie</param>
        public void AjouterCategorie(Categories c)
        {
            listAff.Clear();
            foreach (Manga m in ListManga)
            {
                if(m.Categorie == c)
                {
                    ListAff.Add(m);
                }
            }
        }

        /// <summary>
        /// Ajouter un manga à ListFavories
        /// </summary>
        /// <param name="m1">Manga choisi</param>
        public void AjouterFav(Manga m1) 
        {
            ListFavories.Insert(ListFavories.Count, m1); 
            ListFavories.Sort();          
            m1.Favoris = true;
        }

        /// <summary>
        /// Supprime un manga de ListFavories
        /// </summary>
        /// <param name="m1">Manga choisi</param>
        public void SupprimerFav(Manga m1)  
        {
            ListFavories.Remove(m1);
            m1.Favoris = false;
        }

        /// <summary>
        /// Affiche la list de Favories
        /// </summary>
        /// <returns>aff</returns>
        public String AfficherFav()
        {
            String aff = null;
            foreach (Manga m in ListFavories)
            {
                aff += m + "\n\n";
            }
            return aff;
        }

        /// <summary>
        /// Tri ListManga en fonction de s
        /// </summary>
        /// <param name="s">Texte écrit dans la barre de recherche</param>
        public void TriRecherche(String s, List<Manga> l)
        {
            int i;
            char[] stringDonne = new char[30], stringManga = new char[60];
            string sDonne, sManga ;

            stringDonne = s.ToCharArray();
            listAff.Clear();
            foreach (Manga m in l)
            {
                sDonne = "";
                sManga = "";
                stringManga = m.Nom.ToCharArray();
                
                for (i = 0 ; i < stringDonne.Length ; i++)
                {
                    sDonne += stringDonne[i].ToString();
                    if (stringManga.Length >= stringDonne.Length)
                        sManga += stringManga[i].ToString();
                }
                if (String.Compare(sDonne, sManga) == 0)
                {
                    listAff.Add(m);
                }
            }
        }

        public override string ToString()
        {
            String aff = null;
            aff += "ListManga \n";
            foreach (Manga m in ListManga)
            {
                aff += "\t" + m.Nom + "\n\n";
            }
            return aff;
        }

        public String AffichageListAff()
        {
            String aff = null;
            aff += "ListAff \n";
            foreach (Manga m in ListAff)
            {
                aff += "\t" + m.Nom + "\n\n";
            }
            return aff;
        }

        public String Affichage(List<Manga> l)
        {
            String aff = null;
            foreach (Manga m in l)
            {
                aff += "\t" + m.Nom + "\n\n";
            }
            return aff;
        }

        public String Affichage(ObservableCollection<Manga> l)
        {
            String aff = null;
            foreach (Manga m in l)
            {
                aff += "\t" + m.Nom + "\n\n";
            }
            return aff;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;

namespace Modele
{
    public class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Dependance vers le gestionnaire de persistance
        /// </summary>
        public IPersistanceManager Persistance { get; set; }

        public void ChargeManga()
        {
            var donnees = Persistance.ChargeDonnes();
            foreach (var j in donnees.ListManga)
            {
                ListeDeManga.AjouterManga(j);
            }
            foreach(var j in donnees.ListFavories)
            {
                ListeDeManga.AjouterFav(j);
            }
            foreach(var j in donnees.ListEncour)
            {
                ListeDeManga.AjouterEncour(j);
            }
        }

        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(ListeDeManga);
        }

        public ListeManga ListeDeManga { private set; get; }

        public Manga MangaSelectionnee 
        { 
            get => mangaSelectionnee;
            set
            {
                mangaSelectionnee = value;
                OnpropertyChange(nameof(MangaSelectionnee));
            } 
        }
        private Manga mangaSelectionnee;

        public Manga MangaSelectionneeEncour { set; get; }

        public Episodes EpSelectionnee { get; set; }
    
        public String Text 
        { 
            get => text; 
            set
            {
                text = value;
                OnpropertyChange(nameof(Text));
                ListeDeManga.TriRecherche(Text, ListeDeManga.ListManga);
            }
        }

        private String text;

        public String Text2
        {
            get => text2;
            set
            {
                text2 = value;
                OnpropertyChange(nameof(Text2));
                ListeDeManga.TriRecherche(Text2, ListeDeManga.ListFavories);
            }
        }
        private String text2;

        public void LesLike()
        {
            if(MangaSelectionnee != null)
            {
            int i = 0;

            foreach(Note n in MangaSelectionnee.Notes)
            {
                i += n.Notation;
            }

            MangaSelectionnee.Like = i;
            }

        }

        public Manager(IPersistanceManager persisitance)
        {
            Persistance = persisitance;

            ListeDeManga = persisitance.ChargeDonnes();
            ListeDeManga.ListManga = persisitance.ChargeDonnes().ListManga;
            ListeDeManga.ListEncour = persisitance.ChargeDonnes().ListEncour;
            ListeDeManga.ListFavories = persisitance.ChargeDonnes().ListFavories;
            ListeDeManga = new ListeManga();
            Text = "Recherche";
            Text2 = "Recherche";
            EpSelectionnee = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnpropertyChange(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

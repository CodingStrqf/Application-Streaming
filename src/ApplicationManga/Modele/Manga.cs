using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Modele
{
    public partial class Manga : IEquatable<Manga>, IComparable, INotifyPropertyChanged
    {   
        /// <summary>
        /// Nom du manga
        /// </summary>
        public String Nom { private set; get; } 

        /// <summary>
        /// Description du manga
        /// </summary>
        public String Description {private set; get; }

        /// <summary>
        /// Categorie du manga
        /// </summary>
        public Categories Categorie { private set; get; }

        /// <summary>
        /// Image du manga
        /// </summary>
        public string Image { private set; get; } 

        /// <summary>
        /// Manga en favori oui/non
        /// </summary>
        public bool Favoris { set; get; } 

        /// <summary>
        /// Lien de la bande-d'annonce du manga
        /// </summary>
        public string BandeAnnonce { set; get; }

        /// <summary>
        /// prochain manga a regarder
        /// </summary>
        public Episodes ProchainEpisode 
        {
            set
            {
                prochainEpisode = value;
                OnpropertyChange(nameof(ProchainEpisode));
            }
            get => prochainEpisode;
        }

        private Episodes prochainEpisode;

        public int Like
        {
            set
            {
                like = value;
                OnpropertyChange(nameof(Like));
            }
            get => like;
        }

        private int like;
        
        /// <summary>
        /// Commentaires du manga
        /// </summary>
        public ObservableCollection<Commentaires> Commentaires
        {
            set
            {
                commentaires = value;
                OnpropertyChange(nameof(Commentaires));
            }
            get => commentaires;
        }
        private ObservableCollection<Commentaires> commentaires = new ObservableCollection<Commentaires>();
        

        /// <summary>
        /// Notes du manga
        /// </summary>
        public LinkedList<Note> Notes { get; set; } = new LinkedList<Note>();

        /// <summary>
        /// Episode du manga
        /// </summary>
        public ReadOnlyCollection<Episodes> Ep { get; }

        /// <summary>
        /// Premier constructeur de manga
        /// </summary>
        /// <param name="nom">Nom du manga</param>
        /// <param name="desc">Description du manga</param>
        /// <param name="categ">Categorie du manga</param>
        /// <param name="bandeAnnonce">Lien de la bande d'annonce du manga</param>
        /// <param name="ep"></param>
        /// <param name="image">Image du manga</param>
        public Manga(String nom, String desc, Categories categ,  String bandeAnnonce, List<Episodes> ep, String image = null ) 
        {
            Nom = nom ;
            Description = desc ;
            Image = image;
            Favoris = false;
            Categorie = categ;
            BandeAnnonce = bandeAnnonce;
            ProchainEpisode = null;
            Ep = new ReadOnlyCollection<Episodes>(ep);
        }

        /// <summary>
        /// Second constructeur de manga
        /// </summary>
        /// <param name="nom">Nom du manga</param>
        /// <param name="desc">Decription du manga</param>
        /// <param name="categ">Categorie du manga</param>
        /// <param name="commentaires">Commentaire du manga</param>
        /// <param name="notes">Note du manga</param>
        /// <param name="bandeAnnonce">Lien de la bande d'annonce du manga</param>
        /// <param name="ep"></param>
        /// <param name="pEp"></param>
        /// <param name="image">Image du manga</param>
        public Manga(String nom, String desc, Categories categ, ObservableCollection<Commentaires> commentaires, List<Note> notes, String bandeAnnonce, List<Episodes> ep, Episodes pEp =null , String image = null)
        {
            Nom = nom;
            Description = desc;
            Image = image;
            Favoris = false;
            Categorie = categ;

            foreach(Commentaires c in commentaires)
            {
                Commentaires.Add(c);
            }
            foreach (Note n in notes)
            {
                Notes.AddLast(n);
            }
            
            BandeAnnonce = bandeAnnonce;
            ProchainEpisode = pEp;
            Ep = new ReadOnlyCollection<Episodes>(ep);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnpropertyChange(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // List Episodes fonctions 
        public int GetEpisodeCount()
        {
            return Ep.Count;
        }

        public int GetEpisodeIndex(Episodes ep)
        {
            return Ep.IndexOf(ep);
        }

        public Episodes GetEpisodes(int i)
        {
            return Ep[i];
        }

        // List Episodes fonctions FIN

        /// <summary>
        /// Override la méthode ToString pour la redéfinir
        /// </summary>
        /// <returns>phrase</returns>
        public override string ToString()
        {
            int i= 0,moyenne=0;
            string phrase = "Nom : "+Nom+ "\n" +"Description : "+ Description + "\n"+"Nombre d'épisode : "+ this.Ep.Count + "\n"+"Chemin de l'image : "+ Image + "\n"+"Catégorie : "+Categorie+"\n";
            phrase += "\nListe de commentaire : \n";
            
            foreach(Commentaires com in this.Commentaires) // affiche tous les commentaires
            {
                phrase += com;
            }
            
            foreach(Note note in this.Notes)
            {
                i++;
                moyenne += note.Notation;
            }
            //phrase += "Moyenne : " + moyenne/i +"\n"; //afiche la moyenne
            phrase += "Episodes : \n";
            foreach (Episodes epi in this.Ep) // affiche tous les commentaires
            {
                phrase += epi;
            }
            return phrase;
        }

        public bool Equals([AllowNull] Manga other) => Nom.Equals(other.Nom);

        /// <summary>
        /// Override de la méthode Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>false/true</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals((obj as Manga));
        }

        /// <summary>
        /// Override de la méthode HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Nom.GetHashCode();

        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Manga))
            {
                throw new ArgumentException("Argument is not a Manga", "obj");
            }
            Manga otherManga = obj as Manga;
            return this.CompareTo(otherManga);
        }

        public int CompareTo([AllowNull] Manga other)
        {
            return Nom.CompareTo(other.Nom);
        }
    }

}

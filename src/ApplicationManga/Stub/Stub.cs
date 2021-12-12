using Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        public ListeManga ChargeDonnes()
        {
            ListeManga ListeDeManga = ChargeManga();

            return ListeDeManga;
        }

        public void SauvegardeDonnees(ListeManga ListeDeManga)
        {
            Debug.WriteLine("Sauvegarde demandée");
        }

        public ListeManga ChargeManga()
        {
            ListeManga ListeDeManga = new ListeManga();
            List<Episodes> ep;
            ObservableCollection<Commentaires> c;
            List<Note> n;


            ep = new List<Episodes>();
            ep.Add(new Episodes("Episode 1", "https://animedigitalnetwork.fr/video/attaque-des-titans-shingeki-no-kyojin/13073-episode-1-1"));
            ep.Add(new Episodes("Episode 2", "https://animedigitalnetwork.fr/video/attaque-des-titans-shingeki-no-kyojin/13074-episode-2-2"));
            ep.Add(new Episodes("Episode 3", "https://animedigitalnetwork.fr/video/attaque-des-titans-shingeki-no-kyojin/13075-episode-3-3"));
            c = new ObservableCollection<Commentaires>();
            c.Add(new Commentaires("Jean", "pas trop mal je trouve"));
            c.Add(new Commentaires("Pierre", "Pas a mon gout"));
            n = new List<Note>();
            n.Add(new Note(85));
            Manga SNK = new Manga("Shingeki No kyojin", "aventure extraordinaire, de l'humanité contre ses prédateurs", Categories.Shonen, c, n, "http://fr.vid.web.acsta.net/nmedia/33/14/08/22/17/19547570_hd_013.mp4", ep, null, image: "SNK.png");

            
            ep = new List<Episodes>();
            ep.Add(new Episodes("Episode 1", "https://animedigitalnetwork.fr/video/my-hero-academia/7214-episode-1-izuku-midoriya-les-origines"));
            ep.Add(new Episodes("Episode 2", "https://animedigitalnetwork.fr/video/my-hero-academia/7293-episode-2-les-conditions-au-metier-de-heros"));
            ep.Add(new Episodes("Episode 3", "https://animedigitalnetwork.fr/video/my-hero-academia/7294-episode-3-le-grondement-des-muscles"));
            c = new ObservableCollection<Commentaires>();
            c.Add(new Commentaires("Victor", "pas trop mal je trouve"));
            c.Add(new Commentaires("Paul", "Pas a mon gout"));
            n = new List<Note>();
            n.Add(new Note(10));
            Manga MHA = new Manga("My Hero Academia", "Académie de jeunes héro", Categories.Action, c, n, "https://fr.vid.web.acsta.net/nmedia/33/21/02/24/14/19591453_sd_013.mp4", ep, null, image: "MHA.png");

            ep = new List<Episodes>();
            ep.Add(new Episodes("Episode 1", "https://animedigitalnetwork.fr/video/tokyo-ghoul-saison-1/12917-episode-1-1"));
            ep.Add(new Episodes("Episode 2", "https://animedigitalnetwork.fr/video/tokyo-ghoul-saison-1/12918-episode-2-2"));
            ep.Add(new Episodes("Episode 3", "https://animedigitalnetwork.fr/video/tokyo-ghoul-saison-1/12919-episode-3-3"));
            c = new ObservableCollection<Commentaires>();
            c.Add(new Commentaires("Theo", "pas trop mal je trouve"));
            c.Add(new Commentaires("Justin", "Pas a mon gout"));
            n = new List<Note>();
            n.Add(new Note(50));
            Manga TKG = new Manga("Tokyo Ghoul", "Ghouls", Categories.Horreur, c, n, "http://fr.vid.web.acsta.net/nmedia/33/20/10/27/16//19590402_hd_013.mp4", ep, null, image: "TKG.png");

            ep = new List<Episodes>();
            ep.Add(new Episodes("Episode 1", "https://animedigitalnetwork.fr/video/death-note/7886-episode-1-renaissance"));
            ep.Add(new Episodes("Episode 2", "https://animedigitalnetwork.fr/video/death-note/7888-episode-2-confrontation"));
            ep.Add(new Episodes("Episode 3", "https://animedigitalnetwork.fr/video/death-note/7889-episode-3-pacte"));
            c = new ObservableCollection<Commentaires>();
            c.Add(new Commentaires("Jean", "pas trop mal je trouve"));
            c.Add(new Commentaires("Alex", "Pas a mon gout"));
            n = new List<Note>();
            n.Add(new Note(2));
            Manga DN = new Manga("Death Note", "Phycopate", Categories.Psychologie, c, n, "http://fr.vid.web.acsta.net/nmedia/33/17/06/29/16/19572646_hd_013.mp4", ep, null, image: "DN.png");

            ep = new List<Episodes>();
            ep.Add(new Episodes("Episode 1", "https://voiranime.com/anime/kimetsu-no-yaiba-vf/kimetsu-no-yaiba-demon-slayer-01-vf/"));
            ep.Add(new Episodes("Episode 2", "https://voiranime.com/anime/kimetsu-no-yaiba-vf/kimetsu-no-yaiba-demon-slayer-02-vf/"));
            ep.Add(new Episodes("Episode 3", "https://voiranime.com/anime/kimetsu-no-yaiba-vf/kimetsu-no-yaiba-demon-slayer-03-vf/"));
            c = new ObservableCollection<Commentaires>();
            c.Add(new Commentaires("Lola", "pas trop mal je trouve"));
            c.Add(new Commentaires("Pierre", "Pas a mon gout"));
            n = new List<Note>();
            n.Add(new Note(13));
            Manga DS = new Manga("Demon Slayer", "Chasseur de demon", Categories.Shonen, c, n, "http://fr.vid.web.acsta.net/nmedia/33/21/05/05/14/19592107_hd_013.mp4", ep, null, image: "DS.jpg");

            ep = new List<Episodes>();
            ep.Add(new Episodes("Episode 1", "https://voiranime.com/anime/haikyuu/haikyuu-saison-1-01-vostfr/"));
            ep.Add(new Episodes("Episode 2", "https://voiranime.com/anime/haikyuu/haikyuu-saison-1-02-vostfr/"));
            ep.Add(new Episodes("Episode 3", "https://voiranime.com/anime/haikyuu/haikyuu-saison-1-03-vostfr/"));
            c = new ObservableCollection<Commentaires>();
            c.Add(new Commentaires("Justine", "pas trop mal je trouve"));
            c.Add(new Commentaires("Pierre", "Pas a mon gout"));
            n = new List<Note>();
            n.Add(new Note(59));
            Manga H = new Manga("Haikyuu ", "Volley", Categories.Sport, c, n, "http://fr.vid.web.acsta.net/nmedia/33/20/05/12/10//19588632_hd_013.mp4", ep, null, image: "H.jpg");
            
            ListeDeManga.AjouterManga(SNK);
            ListeDeManga.AjouterManga(MHA);
            ListeDeManga.AjouterManga(TKG);
            ListeDeManga.AjouterManga(DN);
            ListeDeManga.AjouterManga(DS);
            ListeDeManga.AjouterManga(H);
            
            ListeDeManga.AjouterFav(SNK);
            ListeDeManga.AjouterFav(MHA);

            ListeDeManga.CreationAff();
            return ListeDeManga;
        }
    }
}

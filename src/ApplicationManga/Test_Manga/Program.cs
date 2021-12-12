using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Modele;
using System.Linq;

namespace Test_Manga
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Manager mgr = new Manager(new Stub.Stub());

            mgr.ChargeManga();

            //p.Test(mgr); //Test du tri par catégories

            p.Test1(mgr); //Test du tri par recherche

            //p.Test2(mgr); //Test du tri par favories

            //p.TestEncours(mgr); // Test les fonctionnalités de Encour
            
            //p.TestFav(mgr); // Test la mise de manga en favoris et enlèvement
        }

        public void Test(Manager mgr)
        {
            Console.WriteLine("List de tous les mangas : \n" + mgr.ListeDeManga.ToString());

            mgr.ListeDeManga.AjouterCategorie(Categories.Shonen);

            Console.WriteLine("Test : \n" + mgr.ListeDeManga.AffichageListAff());

        }

        public void Test1(Manager mgr)
        {
           Console.WriteLine("List de tous les mangas : \n" + mgr.ListeDeManga.ToString());

            mgr.ListeDeManga.TriRecherche("My Hero",mgr.ListeDeManga.ListManga);

            Console.WriteLine("Test : \n" + mgr.ListeDeManga.AffichageListAff());
        }

        public void Test2(Manager mgr)
        {
            Console.WriteLine("List de tous les mangas : \n" + mgr.ListeDeManga.ToString());

            Console.WriteLine("Test : \n" + mgr.ListeDeManga.AfficherFav());
        }

        public void TestEncours(Manager mgr)
        {
            string msg = "après avoir cliqué sur un épisode dans le userControle qui est la fiche de manga";
            Console.WriteLine("List de tous les mangas Encours: \n" + mgr.ListeDeManga.Affichage(mgr.ListeDeManga.ListEncour) + "\n");

            mgr.MangaSelectionnee = mgr.ListeDeManga.ListManga[1];
            mgr.EpSelectionnee = mgr.MangaSelectionnee.Ep[0];

            //code du bouton UserControle1

            if (mgr.EpSelectionnee != null)
            {
                if (!mgr.ListeDeManga.ListEncour.Contains(mgr.MangaSelectionnee))
                {
                    mgr.ListeDeManga.AjouterEncour(mgr.MangaSelectionnee);
                }

                mgr.ListeDeManga.ProchainEpisode(mgr.MangaSelectionnee, mgr.EpSelectionnee);
            }

            //code du bouton UserControle1 FIN
            mgr.MangaSelectionneeEncour = mgr.ListeDeManga.ListEncour[0];

            Console.WriteLine("List de tous les mangas Encours "+msg+" : \n[ " + mgr.ListeDeManga.Affichage(mgr.ListeDeManga.ListEncour)+" ]\n");

            for(int i =1; i<4; i++)
            {
                Console.WriteLine("appuyer sur entrer");
                Console.ReadLine();
                Console.Clear();
                msg = "Après avoir cliqué " + i + " fois sur le bouton dans Mainwindow de la liste encours";

                Console.WriteLine("List de tous les mangas Encours " + msg + " : \n[ " + mgr.ListeDeManga.Affichage(mgr.ListeDeManga.ListEncour) + " ]\n");

                if (mgr.ListeDeManga.ListEncour.Count != 0)
                    Console.WriteLine("Episode qui sera ouvert après se clique : " + mgr.MangaSelectionnee.ProchainEpisode.Nom+"\n");
                
                mgr.ListeDeManga.ProchainEpisode(mgr.MangaSelectionneeEncour, mgr.MangaSelectionneeEncour.ProchainEpisode);

                if (mgr.ListeDeManga.ListEncour.Count != 0)
                    Console.WriteLine("L' episode affiché dans liste encours après se clique sera :" + mgr.MangaSelectionnee.ProchainEpisode.Nom + "\n");
            }
            //code du bouton MainWindow

        }

        public void TestFav(Manager mgr)
        {
            string msg = "apparut";

            Console.WriteLine("List de tous les mangas Fav: \n" + mgr.ListeDeManga.Affichage(mgr.ListeDeManga.ListFavories));

            mgr.MangaSelectionnee = mgr.ListeDeManga.ListManga[2];

            for (int i = 0; i<2; i++)
            {
                Console.WriteLine("appuyer sur entrer");
                Console.ReadLine();
                Console.Clear();
            // code dans le bouton
            
            if (mgr.MangaSelectionnee.Favoris)
            {
                mgr.ListeDeManga.SupprimerFav(mgr.MangaSelectionnee);
            }
            else
            {
                mgr.ListeDeManga.AjouterFav(mgr.MangaSelectionnee);
            }

                // code dans le bouton FIN

            Console.WriteLine("List de tous les mangas Fav: \n" + mgr.ListeDeManga.Affichage(mgr.ListeDeManga.ListFavories) + "\n Le Manga Haikyuu est "+msg+" \n\n");
                msg = "disparut";
            }

        }

    }
}

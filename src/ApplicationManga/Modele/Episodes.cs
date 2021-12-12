using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Modele
{
    public class Episodes
    {
        /// <summary>
        /// Nom de l'épisode
        /// </summary>
        public string Nom { get;private set; }

        /// <summary>
        /// Lien de l'épisode
        /// </summary>
        public string Lien { get;private set; }
   
        /// <summary>
        /// Constructeur de Episodes
        /// </summary>
        /// <param name="nom">Nom de l'épisode</param>
        /// <param name="lien">Lien de l'épisode</param>
        public Episodes(string nom, string lien)
        {
            Nom = nom;
            Lien = lien;
            // lien : https://voiranime.com/anime/shingeki-no-kyojin-vf/shingeki-no-kyojin-attaque-des-titans/
        }

        /// <summary>
        /// Permet d'ouvrire le lien de l'épisode
        /// </summary>
        public void Ouverture()
        {
            _ = Process.Start("C:/Program Files (x86)/Google/Chrome/Application/chrome.exe", this.Lien);// lien de chrome 

            //_ = Process.Start("C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe", this.Lien); //lien de brave

            //_ = Process.Start("C:/Program Files/Mozilla Firefox/firefox.exe", this.Lien); //lien de firefox
        }

        public void Ouverture(Episodes ep)
        {
            _ = Process.Start("C:/Program Files (x86)/Google/Chrome/Application/chrome.exe", ep.Lien);// lien de chrome 

            // _ = Process.Start("C:/Program Files/BraveSoftware/Brave-Browser/Application/brave.exe", this.Lien); //lien de brave

            //_ = Process.Start("C:/Program Files/Mozilla Firefox/firefox.exe", this.Lien); //lien de firefox
        }

        /// <summary>
        /// Override la méthode ToString pour la redéfinir
        /// </summary>
        /// <returns>"Nom : " suivi du nom et "Lien :" suivi du lien</returns>
        public override string ToString()
        {
            return "Nom : " + Nom + "\t Lien :" + Lien+"\n";
        }

    }
}

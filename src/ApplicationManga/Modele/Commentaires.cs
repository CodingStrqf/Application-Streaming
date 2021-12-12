using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Commentaires
    {
        /// <summary>
        /// Auteur d'un commentaire
        /// </summary>
        public string Auteur { get; private set; }

        /// <summary>
        /// Commentaire d'un utilisateur (auteur)
        /// </summary>
        public string Commentaire { get; private set; }

        /// <summary>
        /// Constructeur de Commentaire
        /// </summary>
        /// <param name="auteur">Auteur d'un commentaire</param>
        /// <param name="commentaire">Commentaire de l'auteur</param>
        public Commentaires(string auteur, string commentaire)
        {
            Auteur = auteur;
            Commentaire = commentaire;
        }

        /// <summary>
        /// Override la méthode ToString pour la redéfinir
        /// </summary>
        /// <returns>"AUTEUR : " suivi de l'auteur et "COMMENTAIRE :" suivi du commentaire</returns>
        public override string ToString()
        {
            return "AUTEUR : " + Auteur + "\n" + "COMMENTAIRE : " + Commentaire + "\n";
        }
    }
}

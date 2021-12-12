using Modele;
using System;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PersLINQXML
{
    public class PersXML : IPersistanceManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//LINQ_XML");

        public string FileName { get; set; } = "appli.xml";

        string PersFile => Path.Combine(FilePath, FileName);
        public ListeManga ChargeDonnes()
        {
            //pour pouvoir utiliser la sauvegarde    
            ListeManga l = new ListeManga();
            //pour pouvoir utiliser la sauvegarde    

            /*
         if (!File.Exists(PersFile))
             return new ListeManga();

         XDocument persistanceTree = XDocument.Load(PersFile);

         var mangas = persistanceTree.Descendants("manga").Select(test => new Manga(

             test.Attribute("nom").Value,

             test.Attribute("description").Value,
             (Categories)Enum.Parse(typeof(Categories), test.Attribute("categorie").Value),

             test.Descendants("commentaire").Select(test => 
             new Commentaires(test.Attribute("auteur").Value, test.Attribute("commentaire").Value)).ToList(),

             test.Descendants("note").Select(test =>
             new Note(XmlConvert.ToInt32(test.Attribute("note").Value))).ToList(),

             test.Attribute("bande annonce").Value,

             test.Descendants("episodes").Select(ep =>
                 new Episodes(ep.Attribute("nomep").Value, ep.Attribute("lien").Value)).ToList(),

             test.Descendants("prochainep").Select(pep=>
                 new Episodes(pep.Attribute("nomep").Value, pep.Attribute("lien").Value)),
             test.Attribute("image").Value
             )); 
            return (ListeManga)mangas;
         */

            return (ListeManga)l;
        }

        /*private static XAttribute XAttributeIfNotNull(string name, string value)
            => string.IsNullOrWhiteSpace(value) ? null : new XAttribute(name, value);

        private static XAttribute XAttributeIfNotNull(string name, object value)
            => value == null ? null : new XAttribute(name, value);*/

        public void SauvegardeDonnees(ListeManga ListeDeManga)
        {
            XDocument persistanceTree = new XDocument();

            var test = ListeDeManga.ListManga.Select(j =>
                new XElement("manga",
                new XAttribute("nom", j.Nom),
                new XAttribute("description", j.Description),
                new XAttribute("categorie", j.Categorie),
                new XElement("commentaire", j.Commentaires.Select(c =>
                     new XElement("com",
                         new XAttribute("auteur", c.Auteur),
                         new XAttribute("commentaire", c.Commentaire)))),
                new XElement("note", j.Notes.Select(n =>
                    new XElement("notation",
                    new XAttribute("note", n.Notation)))),
                new XAttribute("bandeannonce", j.BandeAnnonce),
                new XElement("episodes", j.Ep.Select(e =>
                    new XElement("episode",
                    new XAttribute("nomep", e.Nom),
                    new XAttribute("lien", e.Lien)))),
                //new XElement("prochainep", new XElement("pep" ,new XAttribute("nomep", j.ProchainEpisode.Nom), new XAttribute("lien", j.ProchainEpisode.Lien)) ),
                //new XElement("prochainep", j.ProchainEpisode.Nom, j.ProchainEpisode.Lien ),
                j.ProchainEpisode == null ? null : new XElement("prochainep", new XAttribute("nomep", j.ProchainEpisode.Nom), new XAttribute("lien", j.ProchainEpisode.Lien)),
                new XAttribute("image", j.Image)
                )) ;
            var essai = ListeDeManga.ListFavories.Select(j =>
                new XElement("fav",
                new XAttribute("nom", j.Nom),
                new XAttribute("description", j.Description),
                new XAttribute("categorie", j.Categorie),
                new XElement("commentaire", j.Commentaires.Select(c =>
                     new XElement("com",
                         new XAttribute("auteur", c.Auteur),
                         new XAttribute("commentaire", c.Commentaire)))),
                new XElement("note", j.Notes.Select(n =>
                    new XElement("notation",
                    new XAttribute("note", n.Notation)))),
                new XAttribute("bandeannonce", j.BandeAnnonce),
                new XElement("episodes", j.Ep.Select(e =>
                    new XElement("episode",
                    new XAttribute("NomEp", e.Nom),
                    new XAttribute("Lien", e.Lien)))),
                j.ProchainEpisode == null ? null : new XElement("prochainep", new XAttribute("nomep", j.ProchainEpisode.Nom), new XAttribute("lien", j.ProchainEpisode.Lien)),
                new XAttribute("image", j.Image)
               ));
            var teste = ListeDeManga.ListEncour.Select(j =>
               new XElement("cours",
                new XAttribute("nom", j.Nom),
                new XAttribute("description", j.Description),
                new XAttribute("categorie", j.Categorie),
                new XElement("commentaire", j.Commentaires.Select(c =>
                     new XElement("com",
                         new XAttribute("auteur", c.Auteur),
                         new XAttribute("commentaire", c.Commentaire)))),
                new XElement("note", j.Notes.Select(n =>
                    new XElement("notation",
                    new XAttribute("note", n.Notation)))),
                new XAttribute("bandeannonce", j.BandeAnnonce),
                new XElement("episodes", j.Ep.Select(e =>
                    new XElement("episode",
                    new XAttribute("NomEp", e.Nom),
                    new XAttribute("Lien", e.Lien)))),
                j.ProchainEpisode == null ? null : new XElement("prochainep", new XAttribute("nomep", j.ProchainEpisode.Nom), new XAttribute("lien", j.ProchainEpisode.Lien)),
                new XAttribute("image", j.Image)
               ));

            persistanceTree.Add(new XElement("data",
                new XElement("manga", test),
                new XElement("fav",essai),
                new XElement("cours",teste)));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            Debug.WriteLine(PersFile);
            using (TextWriter tw = File.CreateText(PersFile))
            using (XmlWriter writer = XmlWriter.Create(tw, settings))
            {
                persistanceTree.Save(writer);
            }
        }
    }
}


  
    
        
    


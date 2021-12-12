using Modele;
using PersLINQXML;
using Stub;
using System;

namespace Test_LINQXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new Stub.Stub());
            manager.ChargeManga();
            manager.Persistance = new PersXML();
            manager.SauvegardeDonnees();
        }
    }
}

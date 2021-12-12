using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public interface IPersistanceManager
    {
        ListeManga ChargeDonnes();

        void SauvegardeDonnees(ListeManga ListeDeManga);
    }
}

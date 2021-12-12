using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Modele
{
    public partial class Manga
    {
        private class MangaComparer : IComparer<Manga>
        {
            public int Compare([AllowNull] Manga x, [AllowNull] Manga y)
            {
                return x.Nom.CompareTo(y.Nom);
            }
        }

        public static IComparer<Manga> NomComparer
        {
            get
            {
                if(nomComparer == null)
                {
                    nomComparer = new MangaComparer();
                }
                return nomComparer;
            }
        }
        private static MangaComparer nomComparer = null;
    }
}

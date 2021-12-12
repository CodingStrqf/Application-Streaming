using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Modele
{
    public partial class Manga
    {
        private class MangaEqualityComparer : EqualityComparer<Manga>
        {
            public override bool Equals([AllowNull] Manga x, [AllowNull] Manga y)
            {
                return x.Nom.Equals(y.Nom);
            }

            public override int GetHashCode([DisallowNull] Manga obj)
            {
                return obj.GetHashCode();
            }
        }

        public static IEqualityComparer<Manga> FullEqComparer
        {
            get
            {
                if (mangaEqualityComparer == null)
                {
                    mangaEqualityComparer = new MangaEqualityComparer();
                }
                return mangaEqualityComparer;
            }
        }
        private static MangaEqualityComparer mangaEqualityComparer = null;
    }
}

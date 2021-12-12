using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Note
    {
        /// <summary>
        /// Notation d'un manga
        /// </summary>
        public int Notation { get; private set; }
    
        /// <summary>
        /// Constructeur de Note  
        /// </summary>
        /// <param name="notation">Note appliquer à un manga</param>
        public Note(int notation)
        {
            Notation = notation;
        }
}
}
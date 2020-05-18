using System;
using System.Collections.Generic;

namespace EFTest
{
    //Entité principale
    public partial class Auteur
    {
        public Auteur()
        {
            LivreAuteurs = new HashSet<LivreAuteur>();
        }
        
        //Représentation de clé primaire
        public int Id{ get; set; }
        public string Nom { get; set; }
        //Représentation de clé étrangère
        public int LivreId { get; set; }
        //Propriété de naviguation
        public ICollection<LivreAuteur> LivreAuteurs { get; set; }
    }


    
}

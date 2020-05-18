using System;
using System.Collections.Generic;

namespace EFTest
{
    //Entité  dépendante
    public partial class Livre
    {
        public Livre()
        {
            LivreAuteurs = new HashSet<LivreAuteur>();
        }
        
        //Représentation de clé primaire
        public int Id { get; set; }
        public string Titre { get; set; }
        //Représentation de clé étrangère
        public int AuteurId { get; set; }
        //Propriété de naviguation
        public ICollection<LivreAuteur> LivreAuteurs { get; set; }
    }
}






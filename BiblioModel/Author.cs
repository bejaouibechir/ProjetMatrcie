using System.Collections.Generic;

namespace BiblioModel
{
    public class Author :ApplicationUser
    {
        public Author()
        {
            Role.Descriminator = Descriminator.Author;
        }
        public HashSet<Palmares> PalmaresCollection { get; set; }
    }
}

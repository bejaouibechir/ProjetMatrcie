using Microsoft.AspNetCore.Identity;

namespace BiblioModel
{
    public class ApplicationRole :IdentityRole
    {
        private string _name;

        public override string Name 
        {
            get => _name;
            set
                {
                switch (Descriminator)
                {
                    case global::Descriminator.Author:
                        _name = "Author";
                        break;
                    case global::Descriminator.Visitor:
                        _name = "Visitor";
                        break;
                    case global::Descriminator.Administrator:
                        _name = "Administrator";
                        break;
                    default:
                        throw new RoleNotSetException("Le rôle de l'utilisateur n'est pas ecore" +
                            "définit");
                }

            }
        }

        public Descriminator Descriminator { get; set; }
    }

   
}

public enum Descriminator { Author,Visitor,Administrator}
namespace BiblioModel
{
    public class Visitor :ApplicationUser
    {
        public Visitor()
        {
            Role.Descriminator = Descriminator.Visitor;
        }
    }
}

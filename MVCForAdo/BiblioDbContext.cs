using Microsoft.EntityFrameworkCore;

namespace MVCForAdo
{
    public class BiblioDbContext :DbContext
    {
        public BiblioDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=PC2020\BI2020;" +
                            "Initial Catalog=Test;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Livre> Livres { get; set; }

    }

    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
    }
}

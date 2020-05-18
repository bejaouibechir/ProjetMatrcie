using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFTest
{
    public partial class BiblioDbContext : DbContext
    {
        public BiblioDbContext()
        {
        }

        

        public BiblioDbContext(DbContextOptions<BiblioDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=PC2020\\BI2020;Initial Catalog=Test2;Integrated Security=True");
            }
        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivreAuteur>()
                 .HasKey(la => new { la.AuteurId, la.LivreId });

            modelBuilder.Entity<Auteur>()
                .HasMany(l => l.LivreAuteurs)
                .WithOne(a => a.Auteur);

            modelBuilder.Entity<Livre>()
                .HasMany(a => a.LivreAuteurs)
                .WithOne(l => l.Livre);
        }
    }

}

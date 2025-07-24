using ApiTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set;}
        public DbSet<AnalistaRH> Analistas { get; set;}
        public DbSet<Projeto> Projetos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desenvolvedor>()
                .HasOne(d => d.Projeto)
                .WithMany(p => p.Desenvolvedores)
                .HasForeignKey(d => d.IdProjeto);
        }

    }
}

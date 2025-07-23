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

    }
}

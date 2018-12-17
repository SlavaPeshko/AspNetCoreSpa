using Microsoft.EntityFrameworkCore;
using TestClient.WebApi.Models;

namespace TestClient.WebApi.Context
{
    public class TestClientContext : DbContext
    {
        public TestClientContext(DbContextOptions<TestClientContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable("Clients");

            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .Property(c => c.ClinetCode)
                .HasColumnType("varchar(5)");

            modelBuilder.Entity<Country>()
                .ToTable("Countries");

            modelBuilder.Entity<Country>()
                .Property(c => c.CountryRegioneCode)
                .HasColumnType("varchar(2)");

            modelBuilder.Entity<Country>()
                .HasMany(co => co.Clients)
                .WithOne(cl => cl.Country);

            base.OnModelCreating(modelBuilder);
        }
    }
}

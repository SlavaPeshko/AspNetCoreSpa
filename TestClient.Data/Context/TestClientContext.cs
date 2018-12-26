using Microsoft.EntityFrameworkCore;
using TestClient.Domain.Enities;

namespace TestClient.Data.Context
{
    public class TestClientContext : DbContext
    {
        public TestClientContext(DbContextOptions<TestClientContext> options) : base(options)
        {
            // Database.EnsureCreated();
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

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}

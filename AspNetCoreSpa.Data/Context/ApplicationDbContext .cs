using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<User>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                .Property(c => c.UserCode)
                .HasColumnType("varchar(5)");

            modelBuilder.Entity<User>()
                .HasIndex(c => c.UserCode)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .ToTable("Countries");

            modelBuilder.Entity<Country>()
                .Property(c => c.CountryRegioneCode)
                .HasColumnType("varchar(2)");

            modelBuilder.Entity<Country>()
                .HasMany(co => co.Users)
                .WithOne(cl => cl.Country);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}

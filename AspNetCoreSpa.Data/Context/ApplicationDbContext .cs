using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Security;

namespace AspNetCoreSpa.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<SecurityCode> SecurityCodes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PostImage> Images { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(u => u.Id);
                e.HasIndex(u => u.Email).IsUnique();
                e.HasIndex(u => u.PhoneNumber).IsUnique();

                e.Property(u => u.Email).HasColumnType("nvarchar(100)");
                e.Property(u => u.FirstName).HasColumnType("nvarchar(100)");
                e.Property(u => u.LastName).HasColumnType("nvarchar(100)");
                e.Property(u => u.PasswordHash).HasColumnType("nvarchar(450)");
            });

            modelBuilder.Entity<Country>(e =>
            {
                e.ToTable("Countries");
                e.HasKey(u => u.Id);

                e.Property(c => c.RegionCode).HasColumnType("nvarchar(3)");
                e.Property(u => u.Name).HasColumnType("nvarchar(60)");

                e.HasMany(c => c.Addresses)
                    .WithOne(ur => ur.Country)
                    .HasForeignKey(u => u.CountryId);
            });

            modelBuilder.Entity<UserAddress>(e =>
            {
                e.ToTable("XreUserAddress");
                e.HasKey(ua => new {ua.UserId, ua.AddressId});
                
                e.HasOne(ua => ua.User)
                    .WithMany(u => u.UserAddresses)
                    .HasForeignKey(ua => ua.UserId);
                
                e.HasOne(ua => ua.Address)
                    .WithMany(u => u.UserAddresses)
                    .HasForeignKey(ua => ua.AddressId);
                
                e.HasOne(ua => ua.AddressType)
                    .WithMany(u => u.UserAddresses)
                    .HasForeignKey(ua => ua.AddressTypeId);
            });

            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("XrefUserRole");
                e.HasKey(ur => new { ur.UserId, RoleId = ur.RoleId });

                e.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

                e.HasOne(ur => ur.Role)
                .WithMany(r => r.UsersRoles)
                .HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<SecurityCode>(e =>
            {
                e.ToTable("SecurityCodes");
                e.Property(s => s.Code).HasColumnType("nvarchar(6)");
            });

            modelBuilder.Entity<Post>(e =>
            {
                e.ToTable("Posts");

                e.HasOne(p => p.User)
                .WithMany(u => u.Posts);

                e.Property(p => p.Title).HasMaxLength(100);
                e.Property(p => p.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Comment>(e =>
            {
                e.ToTable("Comments");

                e.HasOne(c => c.User)
                .WithMany(u => u.Comments);

                e.HasOne(c => c.Post)
                .WithMany(p => p.Comments);
            });

            modelBuilder.Entity<Like>(e =>
            {
                e.ToTable("Likes");

                e.HasOne(l => l.Post)
                .WithMany(p => p.Likes);

                e.HasOne(l => l.Comment)
                .WithMany(p => p.Likes);

                e.HasOne(l => l.User)
                .WithMany(p => p.Likes);
            });

            modelBuilder.Entity<PostImage>(e =>
            {
                e.ToTable("Images");

                e.HasOne(i => i.Post)
                .WithMany(p => p.Images);

                e.HasOne(i => i.Post)
                .WithMany(p => p.Images);
            });

            modelBuilder.Entity<RoleClaim>(e =>
            {
                e.ToTable("RoleClaims");

                e.HasOne(r => r.Role)
                .WithMany(r => r.RoleClaims)
                .HasForeignKey(r => r.RoleId);
            });

            // modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}

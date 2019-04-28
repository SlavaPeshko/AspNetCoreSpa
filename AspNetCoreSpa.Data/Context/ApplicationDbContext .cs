﻿using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Security;

namespace AspNetCoreSpa.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<SecurityCode> SecurityCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .ToTable("Countries");
            modelBuilder.Entity<Country>()
                .Property(c => c.RegioneCode)
                .HasColumnType("varchar(2)");

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<SecurityCode>()
                .ToTable("SecurityCodes");
            modelBuilder.Entity<SecurityCode>()
                .Property(s => s.Code)
                .HasColumnType("varchar(6)");

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}

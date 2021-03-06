﻿using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Configurations;
using JWTAuthentication.Data.Seeds;
using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Data.Concrete.EntityFrameworkCore.Contexts
{
    public class JwtDbContext : DbContext
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserSeed());
            modelBuilder.ApplyConfiguration(new AppRoleSeed());
            modelBuilder.ApplyConfiguration(new AppUserRoleSeed());
            modelBuilder.ApplyConfiguration(new ProductSeed());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

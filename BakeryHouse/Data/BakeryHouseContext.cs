using BakeryHouse.Areas.Identity.Data;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Data
{
    public class BakeryHouseContext :IdentityDbContext<CustomUser>
    {
        public BakeryHouseContext(DbContextOptions<BakeryHouseContext> options):base(options)
        {

        }

        public DbSet<Afhaalpunt> Afhaalpunten { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderlijn> Orderlijnen { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Productregel> Productregels { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.HasDefaultSchema("BH");
            modelbuilder.Entity<Klant>().ToTable("Klant");

            modelbuilder.Entity<CustomUser>()
                .HasOne(k => k.Klant)
                .WithOne(c => c.CustomUser)
                .HasForeignKey<Klant>(k => k.UserId);

            modelbuilder.Entity<Order>().ToTable("Order");
            modelbuilder.Entity<Afhaalpunt>().ToTable("Afhaalpunt");
            modelbuilder.Entity<Orderlijn>().ToTable("Orderlijn");
            modelbuilder.Entity<Product>().ToTable("Product");
            modelbuilder.Entity<Productregel>().ToTable("Productregel");
            modelbuilder.Entity<Ingredient>().ToTable("Ingredient").Property(i => i.Prijs).HasColumnType("decimal(18,2)");
        }
    }
}

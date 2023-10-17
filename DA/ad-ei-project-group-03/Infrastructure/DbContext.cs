using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Product> Products { get; set; }//access methods for product entity
        public DbSet<Category> Categories { get; set; } 
        public DbSet<ProductPhoto> Photos { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }  
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }  

        public DbSet<BuyProduct> ShoppingCartProducts { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//
        {
            optionsBuilder.UseSqlite("data source=project.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//database attributes for entities
        {
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<Product>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<ShoppingCart>().HasMany(b =>b.shoppingCartBuyProduct).WithOne(p => p.ShoppingCart);
            modelBuilder.Entity<Product>().HasMany(b => b.ShoppingCartBuyList).WithOne(p => p.Product);
            modelBuilder.Entity<Product>().HasMany(b => b.SpecialOffers).WithOne();

            //modelBuilder.Entity<Product>().HasMany(b => b.ShoppingCart);
            //modelBuilder.Entity<ShoppingCart>().HasMany(b=> b.Products);
           // modelBuilder.Entity<ShoppingCart>().HasMany(b => b.Products).WithMany()
    //        modelBuilder
    //.Entity<ShoppingCart>()
    //.HasMany(p => p.Products)
    //.WithMany(p => p.ShoppingCart)
    //.UsingEntity(j => j.ToTable("PostTags"));

        }

    }
}

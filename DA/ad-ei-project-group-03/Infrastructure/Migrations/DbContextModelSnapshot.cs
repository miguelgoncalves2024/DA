﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30");

            modelBuilder.Entity("DomainLayer.Models.BuyProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartProducts");
                });

            modelBuilder.Entity("DomainLayer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DomainLayer.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("CardNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Clients");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Client");
                });

            modelBuilder.Entity("DomainLayer.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<float>("Salary")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("DomainLayer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    /*b.Property<int>("ProductPhotoId")
                        .HasColumnType("INTEGER");*/

                    b.Property<string>("Provider")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    //b.HasIndex("ProductPhotoId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("DomainLayer.Models.SpecialOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<float>("Discount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId1");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("DomainLayer.Models.ShoppingCart", b =>
                {
                    b.HasBaseType("DomainLayer.Models.Client");

                    b.Property<float>("TotalValue")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("ShoppingCart");
                });

            /*modelBuilder.Entity("DomainLayer.Models.ProductPhoto", b =>
                {
                    b.HasBaseType("DomainLayer.Models.Product");

                    b.Property<byte[]>("photoFile")
                        .HasColumnType("BLOB");

                    b.HasDiscriminator().HasValue("ProductPhoto");
                });*/

            modelBuilder.Entity("DomainLayer.Models.BuyProduct", b =>
                {
                    b.HasOne("DomainLayer.Models.Product", "Product")
                        .WithMany("ShoppingCartBuyList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("shoppingCartBuyProduct")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Models.Client", b =>
                {
                    b.HasOne("DomainLayer.Models.ShoppingCart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("DomainLayer.Models.Product", b =>
                {
                    b.HasOne("DomainLayer.Models.Category", "Category")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    /*b.HasOne("DomainLayer.Models.ProductPhoto", "ProductPhoto")
                        .WithMany()
                        .HasForeignKey("ProductPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();*/
                });

            modelBuilder.Entity("DomainLayer.Models.SpecialOffer", b =>
                {
                    b.HasOne("DomainLayer.Models.Client", null)
                        .WithMany("SpecialOfferList")
                        .HasForeignKey("ClientId");

                    b.HasOne("DomainLayer.Models.Product", null)
                        .WithMany("SpecialOffers")
                        .HasForeignKey("ProductId1");
                });
#pragma warning restore 612, 618
        }
    }
}
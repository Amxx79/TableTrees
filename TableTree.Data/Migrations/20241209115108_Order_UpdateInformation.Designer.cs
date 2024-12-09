﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableTree.Data;

#nullable disable

namespace TableTree.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241209115108_Order_UpdateInformation")]
    partial class Order_UpdateInformation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TableTree.Data.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("TableTree.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TableTree.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"),
                            Name = "Table"
                        },
                        new
                        {
                            Id = new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"),
                            Name = "Bathroom Countertop"
                        },
                        new
                        {
                            Id = new Guid("6acd5822-a59e-4427-b8ac-fbca0751cd98"),
                            Name = "Mirrors"
                        });
                });

            modelBuilder.Entity("TableTree.Data.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("TableTree.Data.Models.FavouriteProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("FavouriteProducts");
                });

            modelBuilder.Entity("TableTree.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TableTree.Data.Models.OrderItemInfo", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TableTree.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("/images/no-image.jpg");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TreeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TreeTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d1050df-82ba-4d99-b0f1-5935ecedd1c0"),
                            CategoryId = new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"),
                            Description = "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.",
                            ImageUrl = "/images/table-1.jpeg",
                            IsDeleted = false,
                            Name = "Reclaimed Wood Counter Top",
                            Price = 450.00m,
                            TreeTypeId = new Guid("401dd5cd-c271-4960-84ce-0b364c96f039")
                        },
                        new
                        {
                            Id = new Guid("16d6f412-614f-404c-878d-aadc46fcec35"),
                            CategoryId = new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"),
                            Description = "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.",
                            ImageUrl = "/images/table-2.jpeg",
                            IsDeleted = false,
                            Name = "Eris Hackberry Blue Epoxy Resin Table",
                            Price = 4800.00m,
                            TreeTypeId = new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766")
                        },
                        new
                        {
                            Id = new Guid("9f07c23a-f6bc-4618-86f9-f34f1eb08735"),
                            CategoryId = new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"),
                            Description = "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.",
                            ImageUrl = "/images/table-3.jpg",
                            IsDeleted = false,
                            Name = "Epoxy resin table olive tree",
                            Price = 1200.00m,
                            TreeTypeId = new Guid("401dd5cd-c271-4960-84ce-0b364c96f039")
                        },
                        new
                        {
                            Id = new Guid("0e1e00b1-cd72-4b5b-9916-3c1d2dc05350"),
                            CategoryId = new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"),
                            Description = "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.",
                            ImageUrl = "/images/table-4.jpeg",
                            IsDeleted = false,
                            Name = "Epoxy Resin River Table",
                            Price = 1199.50m,
                            TreeTypeId = new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766")
                        },
                        new
                        {
                            Id = new Guid("e5cb26d0-e57b-471d-826d-b0c707b5b1ad"),
                            CategoryId = new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"),
                            Description = "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.",
                            ImageUrl = "/images/table-5.jpeg",
                            IsDeleted = false,
                            Name = "Rustic Live Edge Tree Table",
                            Price = 799.99m,
                            TreeTypeId = new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34")
                        });
                });

            modelBuilder.Entity("TableTree.Data.Models.ProductStore", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("TableTree.Data.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityOfProducts")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("TableTree.Data.Models.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f69b658-4422-4bb6-94b1-46a5f146f826"),
                            Address = "Bulgaria, Sofia, Druzhba"
                        },
                        new
                        {
                            Id = new Guid("be64604e-12e3-4872-bd07-242f1e45d0f2"),
                            Address = "Bulgaria, Plovdiv, Trakiya"
                        },
                        new
                        {
                            Id = new Guid("8e37d43e-cdc4-48ca-ade3-63147766cbce"),
                            Address = "Bulgaria, Bourgas, Trakiya"
                        });
                });

            modelBuilder.Entity("TableTree.Data.Models.TreeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfTrees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34"),
                            Name = "Tree"
                        },
                        new
                        {
                            Id = new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766"),
                            Name = "Beech"
                        },
                        new
                        {
                            Id = new Guid("401dd5cd-c271-4960-84ce-0b364c96f039"),
                            Name = "Оак"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TableTree.Data.Models.Comment", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TableTree.Data.Models.FavouriteProduct", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ClientsFavouriteProducts")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.Product", "Product")
                        .WithMany("FavouriteProductsClients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TableTree.Data.Models.Order", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Orders")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("TableTree.Data.Models.OrderItemInfo", b =>
                {
                    b.HasOne("TableTree.Data.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TableTree.Data.Models.Product", b =>
                {
                    b.HasOne("TableTree.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.TreeType", "TreeType")
                        .WithMany("Products")
                        .HasForeignKey("TreeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("TreeType");
                });

            modelBuilder.Entity("TableTree.Data.Models.ProductStore", b =>
                {
                    b.HasOne("TableTree.Data.Models.Product", "Product")
                        .WithMany("ProductStores")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.Store", "Store")
                        .WithMany("StoreProducts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("TableTree.Data.Models.ShoppingCart", b =>
                {
                    b.HasOne("TableTree.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ClientsProducts")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTree.Data.Models.Product", "Product")
                        .WithMany("ProductsClients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TableTree.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("ClientsFavouriteProducts");

                    b.Navigation("ClientsProducts");

                    b.Navigation("Comments");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TableTree.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TableTree.Data.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("TableTree.Data.Models.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavouriteProductsClients");

                    b.Navigation("OrderItems");

                    b.Navigation("ProductStores");

                    b.Navigation("ProductsClients");
                });

            modelBuilder.Entity("TableTree.Data.Models.Store", b =>
                {
                    b.Navigation("StoreProducts");
                });

            modelBuilder.Entity("TableTree.Data.Models.TreeType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}

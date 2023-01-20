﻿// <auto-generated />
using System;
using ECommerceApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230119230807_ProductVisibleDeleteFlags")]
    partial class ProductVisibleDeleteFlags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceApp.Shared.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ECommerceApp.Shared.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId", "ProductTypeId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ECommerceApp.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            Name = "Glass",
                            Url = "glass",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            Name = "Bakelser",
                            Url = "bakelser",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            Name = "Bröd",
                            Url = "bröd",
                            Visible = true
                        });
                });

            modelBuilder.Entity("ECommerceApp.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerceApp.Shared.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ProductId", "ProductTypeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ECommerceApp.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Gräddig och god saffransglass som också blir lysande gul av saffranet.",
                            Featured = true,
                            ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                            Title = "SaffransGlass",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Äkta pistageglass är en av mina absoluta favoriter när det kommer till glass. Den här hemmagjorda varianten blev helt perfekt i både smak och konsistens.",
                            Featured = false,
                            ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                            Title = "PistageGlass",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Glass med äkta vanilj – gör egen vaniljglass med glassmaskin! Grädde, mjölk och äggulor utgör basen till glassen som får smak av socker, vaniljstång och salt.",
                            Featured = false,
                            ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                            Title = "VaniljGlass",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Crunchy Choklad Cookies!!",
                            Featured = false,
                            ImageUrl = "https://bakingamoment.com/wp-content/uploads/2016/09/IMG_0316-chocolate-chip-cookies-1-720x720.jpg",
                            Title = "Choklad Cookie",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Krispiga Kolasnittar!",
                            Featured = false,
                            ImageUrl = "https://ingmar.app/blog/wp-content/uploads/2015/12/kolasnittar2.jpg",
                            Title = "Kola Cookies",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Vårt klassiska recept på Vetebullar/Kanelbullar/Vetebröd, samma recept som återfinns på våra vetemjöls-förpackningar!",
                            Featured = false,
                            ImageUrl = "https://www.kungsornen.se/467791/siteassets/2.-recept/saftigaste-kanelbullarna.jpg?maxwidth=1440",
                            Title = "Kanelbullar",
                            Visible = true
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "GUDOMLIGT GODA SAFFRANSBULLAR Riktigt, riktigt saftiga och goda saffransbullar! Smörkrämsfyllningen gör bullarna extra saftiga & goda!",
                            Featured = true,
                            ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
                            Title = "Saffransbullar",
                            Visible = true
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "lkdfkljdsjkfdlkjfdjlsk",
                            Featured = false,
                            ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
                            Title = "SaffransLimpa",
                            Visible = true
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "-",
                            Featured = false,
                            ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
                            Title = "Bananbröd",
                            Visible = true
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "földsölkfdöklfölsdöklsfd",
                            Featured = true,
                            ImageUrl = "https://ingmar.app/blogg/wp-content/uploads/2020/11/Saffransbullar.jpg",
                            Title = "BarbariBröd",
                            Visible = true
                        });
                });

            modelBuilder.Entity("ECommerceApp.Shared.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gräddglass"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gelato"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sorbé"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fikabröd"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mörka bröd"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ljusa bröd"
                        });
                });

            modelBuilder.Entity("ECommerceApp.Shared.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 3,
                            Deleted = false,
                            OriginalPrice = 100.0m,
                            Price = 80.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 80.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 70.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 49.0m,
                            Price = 30.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 39.0m,
                            Price = 30.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 80.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 70.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 7,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 80.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 7,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 80.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 10,
                            ProductTypeId = 6,
                            Deleted = false,
                            OriginalPrice = 99.0m,
                            Price = 80.0m,
                            Visible = true
                        });
                });

            modelBuilder.Entity("ECommerceApp.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ECommerceApp.Shared.Address", b =>
                {
                    b.HasOne("ECommerceApp.Shared.User", null)
                        .WithOne("Address")
                        .HasForeignKey("ECommerceApp.Shared.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerceApp.Shared.OrderItem", b =>
                {
                    b.HasOne("ECommerceApp.Shared.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApp.Shared.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApp.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ECommerceApp.Shared.Product", b =>
                {
                    b.HasOne("ECommerceApp.Shared.Category", "Catergory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catergory");
                });

            modelBuilder.Entity("ECommerceApp.Shared.ProductVariant", b =>
                {
                    b.HasOne("ECommerceApp.Shared.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApp.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ECommerceApp.Shared.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ECommerceApp.Shared.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("ECommerceApp.Shared.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

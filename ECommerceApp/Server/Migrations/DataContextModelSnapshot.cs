﻿// <auto-generated />
using ECommerceApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceApp.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Gräddig och god saffransglass som också blir lysande gul av saffranet.",
                            ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                            Price = 85.00m,
                            Title = "SaffransGlass"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Äkta pistageglass är en av mina absoluta favoriter när det kommer till glass. Den här hemmagjorda varianten blev helt perfekt i både smak och konsistens.",
                            ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                            Price = 60.0m,
                            Title = "PistageGlass"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Glass med äkta vanilj – gör egen vaniljglass med glassmaskin! Grädde, mjölk och äggulor utgör basen till glassen som får smak av socker, vaniljstång och salt.",
                            ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_217210/cf_259/hemmagjord_vaniljglass.jpg",
                            Price = 30.0m,
                            Title = "VaniljGlass"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

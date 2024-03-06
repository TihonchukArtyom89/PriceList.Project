﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceList.WebApplication.Models;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    [DbContext(typeof(PredpriyatieDbContext))]
    [Migration("20240306120013_ExpandDataModel")]
    partial class ExpandDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceList", b =>
                {
                    b.Property<long?>("PriceListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("PriceListID"), 1L, 1);

                    b.Property<DateTime>("PriceListDateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PriceListDateModyfycation")
                        .HasColumnType("datetime2");

                    b.Property<string>("PriceListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceListID");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.Product", b =>
                {
                    b.Property<long?>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("ProductID"), 1L, 1);

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}

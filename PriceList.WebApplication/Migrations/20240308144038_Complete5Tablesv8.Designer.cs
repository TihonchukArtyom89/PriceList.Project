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
    [Migration("20240308144038_Complete5Tablesv8")]
    partial class Complete5Tablesv8
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

                    b.Property<long?>("PriceListProductPriceListLineID")
                        .HasColumnType("bigint");

                    b.HasKey("PriceListID");

                    b.HasIndex("PriceListProductPriceListLineID");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceListOptionalParameter", b =>
                {
                    b.Property<long?>("OptionalParameterEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("OptionalParameterEntryID"), 1L, 1);

                    b.Property<long?>("OptionalParameterID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("OptionalParameterValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PriceListLineID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("OptionalParameterEntryID");

                    b.ToTable("PriceListOptionalParameters");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceListProduct", b =>
                {
                    b.Property<long?>("PriceListLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("PriceListLineID"), 1L, 1);

                    b.Property<long?>("PriceListID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("PriceListLineID");

                    b.ToTable("PriceListProducts");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.Product", b =>
                {
                    b.Property<long?>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("ProductID"), 1L, 1);

                    b.Property<long?>("PriceListProductPriceListLineID")
                        .HasColumnType("bigint");

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

                    b.HasIndex("PriceListProductPriceListLineID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SportsStore.Models.OptionalParameter", b =>
                {
                    b.Property<long?>("OptionalParameterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("OptionalParameterID"), 1L, 1);

                    b.Property<string>("OptionalParameterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionalParameterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OptionalParameterID");

                    b.ToTable("OptionalParameters");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceList", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.PriceListProduct", null)
                        .WithMany("PriceLists")
                        .HasForeignKey("PriceListProductPriceListLineID");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.Product", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.PriceListProduct", null)
                        .WithMany("Products")
                        .HasForeignKey("PriceListProductPriceListLineID");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceListProduct", b =>
                {
                    b.Navigation("PriceLists");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}

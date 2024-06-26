﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceList.WebApplication.Models;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    [DbContext(typeof(PredpriyatieDbContext))]
    partial class PredpriyatieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PriceList.WebApplication.Models.Category", b =>
                {
                    b.Property<long?>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.OptionalParameter", b =>
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

                    b.HasIndex("OptionalParameterID");

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

                    b.Property<long>("PriceListOptionalParametersOptionalParameterEntryID")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("PriceListLineID");

                    b.HasIndex("PriceListOptionalParametersOptionalParameterEntryID");

                    b.ToTable("PriceListProducts");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.Product", b =>
                {
                    b.Property<long?>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("ProductID"), 1L, 1);

                    b.Property<long?>("CategoryID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceListPriceListProduct", b =>
                {
                    b.Property<long>("PriceListProductsPriceListLineID")
                        .HasColumnType("bigint");

                    b.Property<long>("PriceListsPriceListID")
                        .HasColumnType("bigint");

                    b.HasKey("PriceListProductsPriceListLineID", "PriceListsPriceListID");

                    b.HasIndex("PriceListsPriceListID");

                    b.ToTable("PriceListPriceListProduct");
                });

            modelBuilder.Entity("PriceListProductProduct", b =>
                {
                    b.Property<long>("PriceListProductsPriceListLineID")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductsProductID")
                        .HasColumnType("bigint");

                    b.HasKey("PriceListProductsPriceListLineID", "ProductsProductID");

                    b.HasIndex("ProductsProductID");

                    b.ToTable("PriceListProductProduct");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceListOptionalParameter", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.OptionalParameter", "OptionalParameter")
                        .WithMany("PriceListOptionalParameters")
                        .HasForeignKey("OptionalParameterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OptionalParameter");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceListProduct", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.PriceListOptionalParameter", "PriceListOptionalParameters")
                        .WithMany("PriceListProducts")
                        .HasForeignKey("PriceListOptionalParametersOptionalParameterEntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceListOptionalParameters");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.Product", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PriceListPriceListProduct", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.PriceListProduct", null)
                        .WithMany()
                        .HasForeignKey("PriceListProductsPriceListLineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceList.WebApplication.Models.PriceList", null)
                        .WithMany()
                        .HasForeignKey("PriceListsPriceListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PriceListProductProduct", b =>
                {
                    b.HasOne("PriceList.WebApplication.Models.PriceListProduct", null)
                        .WithMany()
                        .HasForeignKey("PriceListProductsPriceListLineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceList.WebApplication.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.OptionalParameter", b =>
                {
                    b.Navigation("PriceListOptionalParameters");
                });

            modelBuilder.Entity("PriceList.WebApplication.Models.PriceListOptionalParameter", b =>
                {
                    b.Navigation("PriceListProducts");
                });
#pragma warning restore 612, 618
        }
    }
}

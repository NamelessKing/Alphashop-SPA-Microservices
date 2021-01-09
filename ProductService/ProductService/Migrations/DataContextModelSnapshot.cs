﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Data;

namespace ProductService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductService.Models.Article", b =>
                {
                    b.Property<string>("ArticleId")
                        .HasColumnName("CodArt")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ArticleStateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AssortmentFamilyId")
                        .HasColumnName("IDFAMASS")
                        .HasColumnType("int");

                    b.Property<string>("CodStat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCreazione")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("IvaId")
                        .HasColumnName("IdIva")
                        .HasColumnType("int");

                    b.Property<double?>("PesoNetto")
                        .HasColumnType("float");

                    b.Property<short?>("PzCart")
                        .HasColumnType("smallint");

                    b.Property<string>("Um")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.HasIndex("AssortmentFamilyId");

                    b.HasIndex("IvaId");

                    b.ToTable("Articoli");
                });

            modelBuilder.Entity("ProductService.Models.AssortmentFamily", b =>
                {
                    b.Property<int>("AssortmentFamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssortmentFamilyId");

                    b.ToTable("FamAssort");
                });

            modelBuilder.Entity("ProductService.Models.Barcode", b =>
                {
                    b.Property<string>("BarcodeId")
                        .HasColumnName("Barcode")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("ArticleId")
                        .HasColumnName("CodArt")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("IdTipoArt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BarcodeId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("ProductService.Models.Ingredient", b =>
                {
                    b.Property<string>("ArticleId")
                        .HasColumnName("CodArt")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.ToTable("Ingredienti");
                });

            modelBuilder.Entity("ProductService.Models.Iva", b =>
                {
                    b.Property<int>("IvaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdIva")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Aliquota")
                        .HasColumnType("smallint");

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IvaId");

                    b.ToTable("Iva");
                });

            modelBuilder.Entity("ProductService.Models.Article", b =>
                {
                    b.HasOne("ProductService.Models.AssortmentFamily", "AssortmentFamily")
                        .WithMany("Articoli")
                        .HasForeignKey("AssortmentFamilyId");

                    b.HasOne("ProductService.Models.Iva", "Iva")
                        .WithMany("Articles")
                        .HasForeignKey("IvaId");
                });

            modelBuilder.Entity("ProductService.Models.Barcode", b =>
                {
                    b.HasOne("ProductService.Models.Article", "Article")
                        .WithMany("Barcodes")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductService.Models.Ingredient", b =>
                {
                    b.HasOne("ProductService.Models.Article", "Article")
                        .WithOne("Ingredient")
                        .HasForeignKey("ProductService.Models.Ingredient", "ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

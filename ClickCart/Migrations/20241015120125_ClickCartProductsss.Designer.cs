﻿// <auto-generated />
/*
using ClickCart.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClickCart.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241015120125_ClickCartProductsss")]
    partial class ClickCartProductsss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClickCart.Models.Productsss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("productsss");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "this is PowerPlay",
                            Name = "PowerPlay"
                        },
                        new
                        {
                            Id = 2,
                            Description = "this is CleanWave",
                            Name = "CleanWave"
                        },
                        new
                        {
                            Id = 3,
                            Description = "this is SnackBox",
                            Name = "SnackBox"
                        },
                        new
                        {
                            Id = 4,
                            Description = "this is Printer",
                            Name = "Printer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
*/
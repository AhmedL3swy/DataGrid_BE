﻿// <auto-generated />
using DataGrid.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataGrid.Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20240909085425_init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataGrid.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ar_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ar_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description 1",
                            Name = "Product 1",
                            Price = 100m,
                            ar_Description = "وصف 1",
                            ar_Name = "منتج 1",
                            stock = 50
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description 2",
                            Name = "Product 2",
                            Price = 200m,
                            ar_Description = "وصف 2",
                            ar_Name = "منتج 2",
                            stock = 100
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description 3",
                            Name = "Product 3",
                            Price = 300m,
                            ar_Description = "وصف 3",
                            ar_Name = "منتج 3",
                            stock = 20
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

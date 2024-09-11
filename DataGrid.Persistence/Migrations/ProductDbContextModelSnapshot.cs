﻿// <auto-generated />
using System;
using DataGrid.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataGrid.Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataGrid.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArName = "الفئة 1",
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            ArName = "الفئة 2",
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            ArName = "الفئة 3",
                            Name = "Category 3"
                        });
                });

            modelBuilder.Entity("DataGrid.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("AddedData")
                        .HasColumnType("date");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("AddedTime")
                        .HasColumnType("time");

                    b.Property<string>("ArDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedData = new DateOnly(2003, 11, 1),
                            AddedOn = new DateTime(2003, 11, 1, 5, 50, 16, 438, DateTimeKind.Local).AddTicks(6468),
                            AddedTime = new TimeOnly(5, 50, 16, 438).Add(TimeSpan.FromTicks(6496)),
                            ArDescription = "وصف 1",
                            ArName = "منتج 1",
                            CategoryId = 1,
                            Description = "Description 1",
                            Name = "Product 1",
                            Price = 100m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            AddedData = new DateOnly(2003, 12, 2),
                            AddedOn = new DateTime(1993, 12, 2, 7, 5, 16, 438, DateTimeKind.Local).AddTicks(6507),
                            AddedTime = new TimeOnly(7, 5, 16, 438).Add(TimeSpan.FromTicks(6509)),
                            ArDescription = "وصف 2",
                            ArName = "منتج 2",
                            CategoryId = 2,
                            Description = "Description 2",
                            Name = "Product 2",
                            Price = 200m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 3,
                            AddedData = new DateOnly(2003, 1, 3),
                            AddedOn = new DateTime(2014, 1, 3, 7, 35, 16, 438, DateTimeKind.Local).AddTicks(6511),
                            AddedTime = new TimeOnly(7, 35, 16, 438).Add(TimeSpan.FromTicks(6514)),
                            ArDescription = "وصف 3",
                            ArName = "منتج 3",
                            CategoryId = 3,
                            Description = "Description 3",
                            Name = "Product 3",
                            Price = 300m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            AddedData = new DateOnly(2003, 2, 4),
                            AddedOn = new DateTime(1999, 2, 4, 8, 50, 16, 438, DateTimeKind.Local).AddTicks(6515),
                            AddedTime = new TimeOnly(8, 50, 16, 438).Add(TimeSpan.FromTicks(6517)),
                            ArDescription = "وصف 4",
                            ArName = "منتج 4",
                            CategoryId = 1,
                            Description = "Description 4",
                            Name = "Product 4",
                            Price = 400m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 5,
                            AddedData = new DateOnly(2003, 3, 5),
                            AddedOn = new DateTime(2004, 3, 5, 10, 5, 16, 438, DateTimeKind.Local).AddTicks(6519),
                            AddedTime = new TimeOnly(10, 5, 16, 438).Add(TimeSpan.FromTicks(6521)),
                            ArDescription = "وصف 5",
                            ArName = "منتج 5",
                            CategoryId = 2,
                            Description = "Description 5",
                            Name = "Product 5",
                            Price = 500m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 6,
                            AddedData = new DateOnly(1997, 4, 6),
                            AddedOn = new DateTime(1984, 4, 5, 20, 35, 16, 438, DateTimeKind.Local).AddTicks(6523),
                            AddedTime = new TimeOnly(20, 35, 16, 438).Add(TimeSpan.FromTicks(6525)),
                            ArDescription = "وصف 6",
                            ArName = "منتج 6",
                            CategoryId = 3,
                            Description = "Description 6",
                            Name = "Product 6",
                            Price = 600m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 7,
                            AddedData = new DateOnly(1995, 5, 7),
                            AddedOn = new DateTime(2004, 5, 7, 0, 35, 16, 438, DateTimeKind.Local).AddTicks(6527),
                            AddedTime = new TimeOnly(17, 35, 16, 438).Add(TimeSpan.FromTicks(6529)),
                            ArDescription = "وصف 7",
                            ArName = "منتج 7",
                            CategoryId = 1,
                            Description = "Description 7",
                            Name = "Product 7",
                            Price = 700m,
                            Stock = 25
                        },
                        new
                        {
                            Id = 8,
                            AddedData = new DateOnly(2003, 6, 8),
                            AddedOn = new DateTime(2004, 5, 6, 18, 50, 16, 438, DateTimeKind.Local).AddTicks(6531),
                            AddedTime = new TimeOnly(18, 50, 16, 438).Add(TimeSpan.FromTicks(6533)),
                            ArDescription = "وصف 8",
                            ArName = "منتج 8",
                            CategoryId = 2,
                            Description = "Description 8",
                            Name = "Product 8",
                            Price = 800m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 9,
                            AddedData = new DateOnly(2003, 5, 9),
                            AddedOn = new DateTime(1997, 7, 3, 20, 20, 16, 438, DateTimeKind.Local).AddTicks(6535),
                            AddedTime = new TimeOnly(20, 20, 16, 438).Add(TimeSpan.FromTicks(6537)),
                            ArDescription = "وصف 9",
                            ArName = "منتج 9",
                            CategoryId = 3,
                            Description = "Description 9",
                            Name = "Product 9",
                            Price = 900m,
                            Stock = 35
                        },
                        new
                        {
                            Id = 10,
                            AddedData = new DateOnly(2004, 8, 10),
                            AddedOn = new DateTime(2000, 8, 4, 23, 50, 16, 438, DateTimeKind.Local).AddTicks(6539),
                            AddedTime = new TimeOnly(23, 50, 16, 438).Add(TimeSpan.FromTicks(6541)),
                            ArDescription = "وصف 10",
                            ArName = "منتج 10",
                            CategoryId = 1,
                            Description = "Description 10",
                            Name = "Product 10",
                            Price = 1000m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 11,
                            AddedData = new DateOnly(1995, 9, 10),
                            AddedOn = new DateTime(2003, 8, 6, 2, 5, 16, 438, DateTimeKind.Local).AddTicks(6543),
                            AddedTime = new TimeOnly(2, 5, 16, 438).Add(TimeSpan.FromTicks(6545)),
                            ArDescription = "وصف 11",
                            ArName = "منتج 11",
                            CategoryId = 2,
                            Description = "Description 11",
                            Name = "Product 11",
                            Price = 1100m,
                            Stock = 40
                        },
                        new
                        {
                            Id = 12,
                            AddedData = new DateOnly(2002, 7, 9),
                            AddedOn = new DateTime(1999, 8, 9, 23, 20, 16, 438, DateTimeKind.Local).AddTicks(6546),
                            AddedTime = new TimeOnly(23, 20, 16, 438).Add(TimeSpan.FromTicks(6548)),
                            ArDescription = "وصف 12",
                            ArName = "منتج 12",
                            CategoryId = 3,
                            Description = "Description 12",
                            Name = "Product 12",
                            Price = 1200m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 13,
                            AddedData = new DateOnly(2003, 8, 8),
                            AddedOn = new DateTime(2004, 8, 6, 20, 35, 16, 438, DateTimeKind.Local).AddTicks(6550),
                            AddedTime = new TimeOnly(20, 35, 16, 438).Add(TimeSpan.FromTicks(6552)),
                            ArDescription = "وصف 13",
                            ArName = "منتج 13",
                            CategoryId = 1,
                            Description = "Description 13",
                            Name = "Product 13",
                            Price = 1300m,
                            Stock = 15
                        });
                });

            modelBuilder.Entity("DataGrid.Domain.Product", b =>
                {
                    b.HasOne("DataGrid.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataGrid.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}

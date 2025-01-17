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

                    b.Property<string>("EnName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArName = "الفئة 1",
                            EnName = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            ArName = "الفئة 2",
                            EnName = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            ArName = "الفئة 3",
                            EnName = "Category 3"
                        });
                });

            modelBuilder.Entity("DataGrid.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("AddedDate")
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

                    b.Property<string>("EnDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnName")
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
                            AddedDate = new DateOnly(2003, 11, 2),
                            AddedOn = new DateTime(2003, 11, 2, 3, 34, 0, 778, DateTimeKind.Local).AddTicks(6496),
                            AddedTime = new TimeOnly(3, 34, 0, 778).Add(TimeSpan.FromTicks(6521)),
                            ArDescription = "وصف 1",
                            ArName = "منتج 1",
                            CategoryId = 1,
                            EnDescription = "EnDescription 1",
                            EnName = "Product 1",
                            Price = 100m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            AddedDate = new DateOnly(2003, 12, 3),
                            AddedOn = new DateTime(1993, 12, 3, 4, 49, 0, 778, DateTimeKind.Local).AddTicks(6528),
                            AddedTime = new TimeOnly(4, 49, 0, 778).Add(TimeSpan.FromTicks(6530)),
                            ArDescription = "وصف 2",
                            ArName = "منتج 2",
                            CategoryId = 2,
                            EnDescription = "EnDescription 2",
                            EnName = "Product 2",
                            Price = 200m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 3,
                            AddedDate = new DateOnly(2003, 1, 4),
                            AddedOn = new DateTime(2014, 1, 4, 5, 19, 0, 778, DateTimeKind.Local).AddTicks(6532),
                            AddedTime = new TimeOnly(5, 19, 0, 778).Add(TimeSpan.FromTicks(6534)),
                            ArDescription = "وصف 3",
                            ArName = "منتج 3",
                            CategoryId = 3,
                            EnDescription = "EnDescription 3",
                            EnName = "Product 3",
                            Price = 300m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            AddedDate = new DateOnly(2003, 2, 5),
                            AddedOn = new DateTime(1999, 2, 5, 6, 34, 0, 778, DateTimeKind.Local).AddTicks(6536),
                            AddedTime = new TimeOnly(6, 34, 0, 778).Add(TimeSpan.FromTicks(6538)),
                            ArDescription = "وصف 4",
                            ArName = "منتج 4",
                            CategoryId = 1,
                            EnDescription = "EnDescription 4",
                            EnName = "Product 4",
                            Price = 400m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 5,
                            AddedDate = new DateOnly(2003, 3, 6),
                            AddedOn = new DateTime(2004, 3, 6, 7, 49, 0, 778, DateTimeKind.Local).AddTicks(6539),
                            AddedTime = new TimeOnly(7, 49, 0, 778).Add(TimeSpan.FromTicks(6541)),
                            ArDescription = "وصف 5",
                            ArName = "منتج 5",
                            CategoryId = 2,
                            EnDescription = "EnDescription 5",
                            EnName = "Product 5",
                            Price = 500m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 6,
                            AddedDate = new DateOnly(1997, 4, 7),
                            AddedOn = new DateTime(1984, 4, 6, 18, 19, 0, 778, DateTimeKind.Local).AddTicks(6543),
                            AddedTime = new TimeOnly(18, 19, 0, 778).Add(TimeSpan.FromTicks(6545)),
                            ArDescription = "وصف 6",
                            ArName = "منتج 6",
                            CategoryId = 3,
                            EnDescription = "EnDescription 6",
                            EnName = "Product 6",
                            Price = 600m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 7,
                            AddedDate = new DateOnly(1995, 5, 8),
                            AddedOn = new DateTime(2004, 5, 7, 22, 19, 0, 778, DateTimeKind.Local).AddTicks(6547),
                            AddedTime = new TimeOnly(15, 19, 0, 778).Add(TimeSpan.FromTicks(6549)),
                            ArDescription = "وصف 7",
                            ArName = "منتج 7",
                            CategoryId = 1,
                            EnDescription = "EnDescription 7",
                            EnName = "Product 7",
                            Price = 700m,
                            Stock = 25
                        },
                        new
                        {
                            Id = 8,
                            AddedDate = new DateOnly(2003, 6, 9),
                            AddedOn = new DateTime(2004, 5, 7, 16, 34, 0, 778, DateTimeKind.Local).AddTicks(6551),
                            AddedTime = new TimeOnly(16, 34, 0, 778).Add(TimeSpan.FromTicks(6553)),
                            ArDescription = "وصف 8",
                            ArName = "منتج 8",
                            CategoryId = 2,
                            EnDescription = "EnDescription 8",
                            EnName = "Product 8",
                            Price = 800m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 9,
                            AddedDate = new DateOnly(2003, 5, 10),
                            AddedOn = new DateTime(1997, 7, 4, 18, 4, 0, 778, DateTimeKind.Local).AddTicks(6555),
                            AddedTime = new TimeOnly(18, 4, 0, 778).Add(TimeSpan.FromTicks(6559)),
                            ArDescription = "وصف 9",
                            ArName = "منتج 9",
                            CategoryId = 3,
                            EnDescription = "EnDescription 9",
                            EnName = "Product 9",
                            Price = 900m,
                            Stock = 35
                        },
                        new
                        {
                            Id = 10,
                            AddedDate = new DateOnly(2004, 8, 11),
                            AddedOn = new DateTime(2000, 8, 5, 21, 34, 0, 778, DateTimeKind.Local).AddTicks(6561),
                            AddedTime = new TimeOnly(21, 34, 0, 778).Add(TimeSpan.FromTicks(6563)),
                            ArDescription = "وصف 10",
                            ArName = "منتج 10",
                            CategoryId = 1,
                            EnDescription = "EnDescription 10",
                            EnName = "Product 10",
                            Price = 1000m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 11,
                            AddedDate = new DateOnly(1995, 9, 11),
                            AddedOn = new DateTime(2003, 8, 6, 23, 49, 0, 778, DateTimeKind.Local).AddTicks(6564),
                            AddedTime = new TimeOnly(23, 49, 0, 778).Add(TimeSpan.FromTicks(6566)),
                            ArDescription = "وصف 11",
                            ArName = "منتج 11",
                            CategoryId = 2,
                            EnDescription = "EnDescription 11",
                            EnName = "Product 11",
                            Price = 1100m,
                            Stock = 40
                        },
                        new
                        {
                            Id = 12,
                            AddedDate = new DateOnly(2002, 7, 10),
                            AddedOn = new DateTime(1999, 8, 10, 21, 4, 0, 778, DateTimeKind.Local).AddTicks(6568),
                            AddedTime = new TimeOnly(21, 4, 0, 778).Add(TimeSpan.FromTicks(6570)),
                            ArDescription = "وصف 12",
                            ArName = "منتج 12",
                            CategoryId = 3,
                            EnDescription = "EnDescription 12",
                            EnName = "Product 12",
                            Price = 1200m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 13,
                            AddedDate = new DateOnly(2003, 8, 9),
                            AddedOn = new DateTime(2004, 8, 7, 18, 19, 0, 778, DateTimeKind.Local).AddTicks(6571),
                            AddedTime = new TimeOnly(18, 19, 0, 778).Add(TimeSpan.FromTicks(6573)),
                            ArDescription = "وصف 13",
                            ArName = "منتج 13",
                            CategoryId = 1,
                            EnDescription = "EnDescription 13",
                            EnName = "Product 13",
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

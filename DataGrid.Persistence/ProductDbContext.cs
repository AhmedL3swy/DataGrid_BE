using DataGrid.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataGrid.Persistence
{
    class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    EnName = "Product 1",
                    ArName = "منتج 1",
                    EnDescription = "EnDescription 1",
                    ArDescription = "وصف 1",
                    Price = 100,
                    Stock = 50,
                    CategoryId = 1,
                    AddedOn = DateTime.Now.AddYears(-20).AddMonths(-10).AddDays(-10).AddHours(-5).AddMinutes(-30),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-20).AddMonths(-10).AddDays(-10)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-5).AddMinutes(-30))
                },
                new Product
                {
                    Id = 2,
                    EnName = "Product 2",
                    ArName = "منتج 2",
                    EnDescription = "EnDescription 2",
                    ArDescription = "وصف 2",
                    Price = 200,
                    Stock = 100,
                    CategoryId = 2,
                    AddedOn = DateTime.Now.AddYears(-30).AddMonths(-9).AddDays(-9).AddHours(-4).AddMinutes(-15),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-20).AddMonths(-9).AddDays(-9)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-4).AddMinutes(-15))
                },
                new Product
                {
                    Id = 3,
                    EnName = "Product 3",
                    ArName = "منتج 3",
                    EnDescription = "EnDescription 3",
                    ArDescription = "وصف 3",
                    Price = 300,
                    Stock = 20,
                    CategoryId = 3,
                    AddedOn = DateTime.Now.AddYears(-10).AddMonths(-8).AddDays(-8).AddHours(-3).AddMinutes(-45),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-8).AddDays(-8)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-3).AddMinutes(-45))
                },
                new Product
                {
                    Id = 4,
                    EnName = "Product 4",
                    ArName = "منتج 4",
                    EnDescription = "EnDescription 4",
                    ArDescription = "وصف 4",
                    Price = 400,
                    Stock = 10,
                    CategoryId = 1,
                    AddedOn = DateTime.Now.AddYears(-25).AddMonths(-7).AddDays(-7).AddHours(-2).AddMinutes(-30),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-7).AddDays(-7)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-2).AddMinutes(-30))
                },
                new Product
                {
                    Id = 5,
                    EnName = "Product 5",
                    ArName = "منتج 5",
                    EnDescription = "EnDescription 5",
                    ArDescription = "وصف 5",
                    Price = 500,
                    Stock = 30,
                    CategoryId = 2,
                    AddedOn = DateTime.Now.AddYears(-20).AddMonths(-6).AddDays(-6).AddHours(-1).AddMinutes(-15),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-6).AddDays(-6)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-1).AddMinutes(-15))
                },
                new Product
                {
                    Id = 6,
                    EnName = "Product 6",
                    ArName = "منتج 6",
                    EnDescription = "EnDescription 6",
                    ArDescription = "وصف 6",
                    Price = 600,
                    Stock = 15,
                    CategoryId = 3,
                    AddedOn = DateTime.Now.AddYears(-40).AddMonths(-5).AddDays(-5).AddHours(-14).AddMinutes(-45),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-27).AddMonths(-5).AddDays(-5)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-14).AddMinutes(-45))
                },
                new Product
                {
                    Id = 7,
                    EnName = "Product 7",
                    ArName = "منتج 7",
                    EnDescription = "EnDescription 7",
                    ArDescription = "وصف 7",
                    Price = 700,
                    Stock = 25,
                    CategoryId = 1,
                    AddedOn = DateTime.Now.AddYears(-20).AddMonths(-4).AddDays(-4).AddHours(-10).AddMinutes(-45),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-29).AddMonths(-4).AddDays(-4)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-17).AddMinutes(-45))
                },
                new Product
                {
                    Id = 8,
                    EnName = "Product 8",
                    ArName = "منتج 8",
                    EnDescription = "EnDescription 8",
                    ArDescription = "وصف 8",
                    Price = 800,
                    Stock = 20,
                    CategoryId = 2,
                    AddedOn = DateTime.Now.AddYears(-20).AddMonths(-3).AddDays(-35).AddHours(-16).AddMinutes(-30),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-3).AddDays(-3)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-16).AddMinutes(-30))
                },
                new Product
                {
                    Id = 9,
                    EnName = "Product 9",
                    ArName = "منتج 9",
                    EnDescription = "EnDescription 9",
                    ArDescription = "وصف 9",
                    Price = 900,
                    Stock = 35,
                    CategoryId = 3,
                    AddedOn = DateTime.Now.AddYears(-27).AddMonths(-2).AddDays(-7).AddHours(-15).AddMinutes(-0),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-4).AddDays(-2)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-15).AddMinutes(-0))
                },
                new Product
                {
                    Id = 10,
                    EnName = "Product 10",
                    ArName = "منتج 10",
                    EnDescription = "EnDescription 10",
                    ArDescription = "وصف 10",
                    Price = 1000,
                    Stock = 5,
                    CategoryId = 1,
                    AddedOn = DateTime.Now.AddYears(-24).AddMonths(-1).AddDays(-6).AddHours(-11).AddMinutes(-30),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-20).AddMonths(-1).AddDays(-1)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-11).AddMinutes(-30))
                },
                new Product
                {
                    Id = 11,
                    EnName = "Product 11",
                    ArName = "منتج 11",
                    EnDescription = "EnDescription 11",
                    ArDescription = "وصف 11",
                    Price = 1100,
                    Stock = 40,
                    CategoryId = 2,
                    AddedOn = DateTime.Now.AddYears(-21).AddMonths(-1).AddDays(-5).AddHours(-9).AddMinutes(-15),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-28).AddMonths(-12).AddDays(-1)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-9).AddMinutes(-15))
                },
                new Product
                {
                    Id = 12,
                    EnName = "Product 12",
                    ArName = "منتج 12",
                    EnDescription = "EnDescription 12",
                    ArDescription = "وصف 12",
                    Price = 1200,
                    Stock = 10,
                    CategoryId = 3,
                    AddedOn = DateTime.Now.AddYears(-25).AddMonths(-1).AddDays(-1).AddHours(-12).AddMinutes(-0),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-22).AddMonths(-2).AddDays(-2)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-12).AddMinutes(-0))
                },
                new Product
                {
                    Id = 13,
                    EnName = "Product 13",
                    ArName = "منتج 13",
                    EnDescription = "EnDescription 13",
                    ArDescription = "وصف 13",
                    Price = 1300,
                    Stock = 15,
                    CategoryId = 1,
                    AddedOn = DateTime.Now.AddYears(-20).AddMonths(-1).AddDays(-4).AddHours(-14).AddMinutes(-45),
                    AddedDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-1).AddDays(-3)),
                    AddedTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-14).AddMinutes(-45))
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    EnName = "Category 1",
                    ArName = "الفئة 1"
                },
                new Category
                {
                    Id = 2,
                    EnName = "Category 2",
                    ArName = "الفئة 2"
                },
                new Category
                {
                    Id = 3,
                    EnName = "Category 3",
                    ArName = "الفئة 3"
                }
            );
        }

    }
}

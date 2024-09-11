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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    ArName = "منتج 1",
                    Description = "Description 1",
                    ArDescription = "وصف 1",
                    Price = 100,
                    Stock = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    ArName = "منتج 2",
                    Description = "Description 2",
                    ArDescription = "وصف 2",
                    Price = 200,
                    Stock = 100
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    ArName = "منتج 3",
                    Description = "Description 3",
                    ArDescription = "وصف 3",
                    Price = 300,
                    Stock = 20
                }
            );
        }

    }
}

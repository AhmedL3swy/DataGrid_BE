using DataGrid.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ar_Name = "منتج 1",
                    Description = "Description 1",
                    ar_Description = "وصف 1",
                    Price = 100,
                    stock = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    ar_Name = "منتج 2",
                    Description = "Description 2",
                    ar_Description = "وصف 2",
                    Price = 200,
                    stock = 100
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    ar_Name = "منتج 3",
                    Description = "Description 3",
                    ar_Description = "وصف 3",
                    Price = 300,
                    stock = 20
                }
            );
        }

    }
}

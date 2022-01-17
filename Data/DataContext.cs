using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> tblProducts { get; set; }

        public DbSet<Supplier> tblSuppliers { get; set; }

        public DbSet<Order> tblOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId= 1, Title="Headphones", Price=200.00, Photo="/images/headphone.png"},
                new Product { ProductId = 2, Title = "Laptop", Price = 800.00, Photo = "/images/laptop.jpg" },
                new Product { ProductId = 3, Title = "Book", Price = 30.00, Photo = "/images/book.png" }
                );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, Name = "Sony", Address = "New York", Country = "USA", Email = "help@sony.com", Phone = "0927420193" },
                new Supplier { SupplierId= 2, Name="Samsung", Address="Seoul", Country="Korea", Email="help@samsung.com", Phone="0291728159"},
                new Supplier { SupplierId =3, Name = "DNA", Address = "Amman", Country = "Jordan", Email = "help@dna.com", Phone = "0777777777" }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId=1, ProductId=1, SupplierId=1, Quantity=1, OrderDate= DateTime.Now.AddDays(-2), TotalPrice=850.0, Status=eStatus.Pending},
                new Order { OrderId = 2, ProductId = 2, SupplierId = 2, Quantity = 1, OrderDate = DateTime.Now.AddDays(-5), TotalPrice = 450.0, Status = eStatus.Processing },
                new Order { OrderId = 3, ProductId = 3, SupplierId = 3, Quantity = 1, OrderDate = DateTime.Now.AddDays(-1), TotalPrice = 150.0, Status = eStatus.Failed },
                new Order { OrderId = 4, ProductId = 2, SupplierId = 1, Quantity = 1, OrderDate = DateTime.Now.AddDays(-10), TotalPrice = 390.0, Status = eStatus.Completed }
                );

        }
    }
}

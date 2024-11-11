using Microsoft.EntityFrameworkCore;
using SimpleApi.Domain.Entity;
using SimpleApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleApi.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.StatusId);

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = (int)Status.Pending, Name = "Pending", Description = "Order has been placed but not yet processed" },
                new OrderStatus { Id = (int)Status.Shipped, Name = "Shipped", Description = "Order has been shipped to the customer" },
                new OrderStatus { Id = (int)Status.Delivered, Name = "Delivered", Description = "Order has been delivered to the customer" },
                new OrderStatus { Id = (int)Status.Canceled, Name = "Canceled", Description = "Order has been canceled" }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using CustomerOrder.Core.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CustomerOrder.Infrastructure.Data
{
    public class CustomerOrder : DbContext
    {
        public CustomerOrder(DbContextOptions<CustomerOrder> options) : base(options) { }

        public DbSet<CustomerOrder> Customers { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<CustomerOrder> CustomerOrders { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerOrder>()
                .HasMany(co => co.Products) 
                .WithOne()
                .HasForeignKey("CustomerOrderId");
        }
    }
}

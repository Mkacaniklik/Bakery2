using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bakery2.Areas.Identity.Data;
using Bakery2.Models;

namespace Bakery2.Models
{
    public class Bakery2Context : DbContext
    {
        public Bakery2Context (DbContextOptions<Bakery2Context> options)
            : base(options)
        {
        }

        public DbSet<Bakery2.Models.Customer> Customer { get; set; } = default!;

        public DbSet<Bakery2.Models.Order> Order { get; set; }

        public DbSet<Bakery2.Models.Products> Products { get; set; }

        public DbSet<Bakery2.Models.Baker> Baker { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

      /*  protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
            .HasOne<Customer>(p => p.Customer)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CustomerId);

            builder.Entity<Order>()
            .HasOne<Products>(p => p.Products)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.ProductId);

            builder.Entity<Products>()
                .HasOne<Baker>(p => p.Baker)
                .WithMany(p => p.ProductsAsChefBaker)
                .HasForeignKey(p => p.BakerId);


        }*/
    }
}

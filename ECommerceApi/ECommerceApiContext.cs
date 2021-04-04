using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerceApi.Data
{
    public class ECommerceApiContext : DbContext
    {
        public ECommerceApiContext(DbContextOptions<ECommerceApiContext> dbContextOptions ):base(dbContextOptions)
        {

        }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}

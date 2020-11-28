using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftApp.Data
{
    public class CraftDbContext : DbContext
    {       
        public CraftDbContext(DbContextOptions<CraftDbContext> options) : base(options)
        {            
        }

        public DbSet<Craft> Crafts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

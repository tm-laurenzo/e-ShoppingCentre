using System;
using Microsoft.EntityFrameworkCore;
using EshoppingCenter.Models;

namespace EshoppingCenter.DataStore
{
    public class EcommerceContext : DbContext
    {

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }



    }
}

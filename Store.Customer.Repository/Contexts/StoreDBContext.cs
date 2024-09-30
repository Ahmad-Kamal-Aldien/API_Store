using Microsoft.EntityFrameworkCore;
using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Repository.Contexts
{
    public class StoreDBContext:DbContext
    {
        public StoreDBContext(DbContextOptions option):base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<ProductBrand> ProductBrand { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

    }
}

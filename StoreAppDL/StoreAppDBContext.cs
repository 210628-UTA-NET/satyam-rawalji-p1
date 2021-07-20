using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppModels;

namespace StoreAppDL
{
    // implement dbcontext
    public class StoreAppDBContext : DbContext 
    {
        // create properties
        // they reference the db, so no need for entities?
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreFront> StoreFronts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        // create constructors
        // use base keyword to have constructors reference base class (s.o.l.i.d principles)
        public StoreAppDBContext(): base() { }

        public StoreAppDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            // These blocks of code auto-generate ID columns
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.CId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<StoreFront>()
                .Property(sf => sf.SFId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .Property(li => li.LId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .Property(o => o.OId)
                .ValueGeneratedOnAdd();
        }
    }
}

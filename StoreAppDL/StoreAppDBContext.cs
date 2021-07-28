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
        public DbSet<Inventory> Inventories { get; set; }

        // create constructors
        // use base keyword to have constructors reference base class (s.o.l.i.d principles)
        public StoreAppDBContext(): base() { }

        public StoreAppDBContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            // These blocks of code auto-generate ID columns
            _modelBuilder.Entity<Customer>()
                .Property(cust => cust.Id)
                .ValueGeneratedOnAdd();

            _modelBuilder.Entity<StoreFront>()
                .Property(sf => sf.Id)
                .ValueGeneratedOnAdd();

            _modelBuilder.Entity<LineItem>()
                .Property(li => li.Id)
                .ValueGeneratedOnAdd();

            _modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            _modelBuilder.Entity<Inventory>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

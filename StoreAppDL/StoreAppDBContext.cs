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

        // will hold the connection string?
        // need to figure out why connection string isnt working in startup.cs
        protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        {
            p_options.UseSqlServer(@"Server=tcp:satyamdb.database.windows.net,1433;
                  Initial Catalog=satyamdb;Persist Security Info=False;User ID=srawalji;
                  Password=Salty3ham4;MultipleActiveResultSets=False;Encrypt=True;
                  TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            // These blocks of code auto-generate ID columns
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<StoreFront>()
                .Property(sf => sf.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .Property(li => li.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

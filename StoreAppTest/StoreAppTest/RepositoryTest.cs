using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreAppDL;
using StoreAppModels;
using Xunit;

namespace StoreAppTest
{
    public class RepositoryTest
    {
        /// <summary>
        /// DBcontext used to access the db
        /// </summary>
        private readonly DbContextOptions<StoreAppDBContext> _options;

        // Constructors in unit tests always run before test cases
        public RepositoryTest()
        {
            // create inline memory database to test
            _options = new DbContextOptionsBuilder<StoreAppDBContext>().UseSqlite("Filename = Test.db").Options;

            // call seed in constructor
            this.Seed();
        }

        /// <summary>
        /// this test should get all stores in the db, use count to double check 
        /// </summary>
        [Fact]
        public void GetAllStoresShouldGetAllStores()
        {
            using(var context = new StoreAppDBContext(_options))
            {
                // Arrange
                IRepository repo = new Repository(context);
                List<StoreFront> storeFronts;

                // Act
                storeFronts = repo.GetAllStores();

                // Assert
                Assert.NotNull(storeFronts);
                Assert.Equal(2, storeFronts.Count);
            }
        }

        /// <summary>
        /// test to make sure search customer function is working
        /// </summary>
        [Fact]
        public void SearchCustomerShouldSearchCustomer()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                // Arrange
                IRepository repo = new Repository(context);
                List<Customer> list = new List<Customer>();
                Customer findCustomer = new Customer()
                {
                    FirstName = "Aaron",
                    MiddleName = "Arn",
                    LastName = "Aaronson",
                    Address = "Rustic Village",
                    City = "English City",
                    State = "England",
                    ZipCode = "12345",
                    Email = "aaa@revature.net",
                    PhoneNumber = "123-456-7890"
                };
                list.Add(findCustomer);

                // Act
                List<Customer> foundCustomer = repo.SearchCustomer(findCustomer.FirstName, findCustomer.LastName);

                // Assert
                Assert.NotNull(foundCustomer);
                Assert.Equal(list.Count, foundCustomer.Count);
            }
        }

        /// <summary>
        /// test to make sure function gets all customers
        /// </summary>
        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                // Arrange
                IRepository repo = new Repository(context);
                List<Customer> list;
                int counter = 1;

                // Act
                list = repo.GetAllCustomers(); 

                // Assert
                Assert.NotNull(list);
                Assert.Equal(list.Count, counter);
            }
        }

        /// <summary>
        /// addcustomer function should add a customer to the db
        /// </summary>
        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                // Arrange
                IRepository repo = new Repository(context);
                Customer customer = new Customer()
                {
                    FirstName = "PAaron",
                    MiddleName = "PArn",
                    LastName = "PAaronson",
                    Address = "PRustic Village",
                    City = "PEnglish City",
                    State = "PEngland",
                    ZipCode = "P12345",
                    Email = "Paaa@revature.net",
                    PhoneNumber = "223-456-7890"
                };
                Customer update;
                int counter = 2;

                // Act
                update = repo.AddCustomer(customer);
                int newCount = repo.GetAllCustomers().Count;

                // Assert
                Assert.NotNull(customer);
                Assert.Equal(newCount, counter);
            }
        }

        // need to fill db
        private void Seed()
        {
            // opens local db for testing, closes for outside function
            using (var context = new StoreAppDBContext(_options))
            {
                // want to make sure inmemory gets deleted everytime before another test case runs it
                context.Database.EnsureDeleted();

                // now recreate db
                context.Database.EnsureCreated();

                // Add data to db
                context.StoreFronts.AddRange(
                    new StoreFront
                    {
                        Name = "Test Store",
                        Address = "Local database"
                    },
                    new StoreFront
                    {
                        Name = "Another Test Store",
                        Address = "Same local DB"
                    }
                );

                // add customer to db
                context.Customers.AddRange(
                    new Customer
                    {
                        FirstName = "Aaron",
                        MiddleName = "Arn",
                        LastName = "Aaronson",
                        Address = "Rustic Village",
                        City = "English City",
                        State = "England",
                        ZipCode = "12345",
                        Email = "aaa@revature.net",
                        PhoneNumber = "123-456-7890"
                    }
                 );

                // save changes
                context.SaveChanges();
            }
        }
    }
}

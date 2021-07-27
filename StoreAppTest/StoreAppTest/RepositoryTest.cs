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
        private readonly DbContextOptions<StoreAppDBContext> _options;
        // Constructors in unit tests always run before test cases
        public RepositoryTest()
        {
            // create inline memory database to test
            _options = new DbContextOptionsBuilder<StoreAppDBContext>().UseSqlite("Filename = Test.db").Options;

            // call seed in constructor
            this.Seed();
        }

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

                // save changes
                context.SaveChanges();
            }
        }
    }
}

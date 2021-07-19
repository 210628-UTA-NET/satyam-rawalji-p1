using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using StoreAppBL;
using StoreAppDL;
using StoreAppDL.Entities;

namespace StoreAppUI {
    public class FactoryMenu : IFactoryMenu {
        public IConsoleMenu GetMenu(MenuType _menu) {

            // json file used to hold connection string
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app_setting.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DBConnString");

            // use dbcontext class to deal with db queries
            DbContextOptions<satyamdbContext> options = new DbContextOptionsBuilder<satyamdbContext>()
                .UseSqlServer(connectionString)
                .Options;

            // user choice will create new menu object that user can interact with
            switch(_menu) {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu(new CustomerBL(new Repository(new satyamdbContext(options))));
                case MenuType.SearchCustomerMenu:
                    return new SearchCustomerMenu(new CustomerBL(new Repository(new satyamdbContext(options))));
                case MenuType.PlaceOrderMenu:
                    return new PlaceOrderMenu(new OrderBL(new Repository(new satyamdbContext(options))),
                                                new StoreFrontBL(new Repository(new satyamdbContext(options))));
                case MenuType.StoreFrontMenu:
                    return new StoreFrontMenu();
                case MenuType.SearchStoreMenu:
                    return new SearchStoreMenu(new StoreFrontBL(new Repository(new satyamdbContext(options))));
                case MenuType.ReplenishStoreMenu:
                    return new ReplenishStoreMenu(new StoreFrontBL(new Repository(new satyamdbContext(options))));
                case MenuType.SearchStoreOrderHistoryMenu:
                    return new SearchStoreOrderHistoryMenu(new StoreFrontBL(new Repository(new satyamdbContext(options))));
                case MenuType.SearchCustomerOrderHistoryMenu:
                    return new SearchCustomerOrderHistoryMenu(new CustomerBL(new Repository(new satyamdbContext(options))));
                default:
                    return null;
            }
        }
    }
}
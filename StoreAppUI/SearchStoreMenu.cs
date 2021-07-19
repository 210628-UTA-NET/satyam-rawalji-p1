using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class SearchStoreMenu : IConsoleMenu {
        // user storefrontbl item to send information to repository in DL
        private IStoreFrontBL _storeFrontBL;
        public SearchStoreMenu(IStoreFrontBL p_storeFrontBL) {
            _storeFrontBL = p_storeFrontBL;
        }

        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Search Store Front Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] View Store Inventory by store name");
            Console.WriteLine("[0] Go back to Store Front Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    // user needs store name to query information
                    Console.WriteLine();
                    Console.WriteLine("Please enter the store name: ");
                    string queryInput = Console.ReadLine();
                    Console.WriteLine();
                    try {
                        // store inventory is stored in lineitem list
                        List<LineItem> queryResult = _storeFrontBL.SearchStore(queryInput);
                        Console.WriteLine("Found Store!");
                        Console.WriteLine("Inventory: \n");
                        // use foreach to display each tuple in db
                        foreach(var query in queryResult) {
                            Console.WriteLine("Product: {0}\n Price: {1}\n Quantity: {2}\n", 
                                                query.Name,
                                                query.Price,
                                                query.Quantity);
                        }
                        Console.WriteLine("Press Enter to go back to Search Customer Menu");
                        Console.ReadLine();
                        return MenuType.SearchStoreMenu;
                    }   
                    catch/*(InvalidOperationException)*/ {
                        Console.WriteLine("Input was not found. Press press enter to try again.");
                        Console.ReadLine();
                        return MenuType.SearchStoreMenu;
                    }
                case "0":
                    return MenuType.StoreFrontMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchStoreMenu;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class SearchStoreOrderHistoryMenu : IConsoleMenu {
        private IStoreFrontBL _storeFrontBL;
        public SearchStoreOrderHistoryMenu(IStoreFrontBL p_storeFrontBL) {
            _storeFrontBL = p_storeFrontBL;
        }
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Search Store Order Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Search for orders by store name");
            Console.WriteLine("[0] Go back to Store Front Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    // user needs store name to get order history
                    Console.WriteLine();
                    Console.WriteLine("Please enter the store name: ");
                    string queryInput = Console.ReadLine();
                    Console.WriteLine();
                    try {
                        // orders are placed into order list
                        List<Order> queryResult = _storeFrontBL.SearchStoreOrders(queryInput);
                        Console.WriteLine("Found Store!");
                        Console.WriteLine("Inventory: \n");
                        // use foreach to display data
                        foreach(var query in queryResult) {
                            Console.WriteLine("Date: {0}  |  Total purchase price: ${1}", 
                                                query.Date,
                                                query.Total);
                        }
                        Console.WriteLine("Press Enter to go back to Store Front Menu");
                        Console.ReadLine();
                        return MenuType.StoreFrontMenu;
                    }   
                    catch/*(InvalidOperationException) */{
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
                    return MenuType.SearchStoreOrderHistoryMenu;
            }
        }
    }
}
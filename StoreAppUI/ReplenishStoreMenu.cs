using System;
using System.Collections.Generic;
using System.Threading;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class ReplenishStoreMenu : IConsoleMenu {
        private IStoreFrontBL _storeFrontBL;
        public ReplenishStoreMenu(IStoreFrontBL p_storeFrontBL) {
            _storeFrontBL = p_storeFrontBL;
        }
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Replenish Inventory Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Choose store to replenish by name");
            Console.WriteLine("[0] Go back to Store Front Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    // user needs store name to replenish store inventory
                    Console.WriteLine();
                    Console.WriteLine("Please enter the store name: ");
                    string queryInput = Console.ReadLine();
                    Console.WriteLine();
                    try {
                        // inventory will be placed into lineitem list
                        List<LineItem> queryResult = _storeFrontBL.SearchStore(queryInput);
                        // use boolean to create semi-infinite while loop
                        bool whileCounter = true;
                        while(whileCounter) {
                            Console.Clear();
                            int counter = 1;
                            // use foreach to display data
                            foreach(var query in queryResult) {
                                Console.WriteLine("[" + counter++ + "] : {0}  |  Quantity: {1}", 
                                                    query.Name,
                                                    query.Quantity);
                            }
                            Console.WriteLine("Choose a product to replenish, choose 9 to update, or choose 0 to exit.");
                            string replenishInput = Console.ReadLine();
                            switch(replenishInput) {
                                case "1":
                                    Console.WriteLine("How many units do you want to add?");
                                    queryResult[0].Quantity += Convert.ToInt32(Console.ReadLine());
                                    continue;
                                case "2":
                                    Console.WriteLine("How many units do you want to add?");
                                    queryResult[1].Quantity += Convert.ToInt32(Console.ReadLine());
                                    continue;
                                case "3":
                                    Console.WriteLine("How many units do you want to add?");
                                    queryResult[2].Quantity += Convert.ToInt32(Console.ReadLine());
                                    continue;
                                case "4":
                                    Console.WriteLine("How many units do you want to add?");
                                    queryResult[3].Quantity += Convert.ToInt32(Console.ReadLine());
                                    continue;
                                case "5":
                                    Console.WriteLine("How many units do you want to add?");
                                    queryResult[4].Quantity += Convert.ToInt32(Console.ReadLine());
                                    continue;
                                case "9":
                                    _storeFrontBL.ReplenishStore(queryResult);
                                    whileCounter = false;
                                    break;
                                case "0":
                                    whileCounter = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Please try again.");
                                    Thread.Sleep(1000);
                                    continue;
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to go back to Search Customer Menu");
                        Console.ReadLine();
                        return MenuType.ReplenishStoreMenu;
                    }   
                    catch/*(InvalidOperationException)*/ {
                        Console.WriteLine("Store was not found. Press press enter to try again.");
                        Console.ReadLine();
                        return MenuType.ReplenishStoreMenu;
                    }
                case "0":
                    return MenuType.StoreFrontMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ReplenishStoreMenu;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class PlaceOrderMenu : IConsoleMenu {
        // orderbl object and storefront bl object created for later repo use
        private IOrderBL _orderBL;
        private IStoreFrontBL _storeFrontBL;
        public PlaceOrderMenu(IOrderBL p_orderBL, IStoreFrontBL p_storeFrontBL) {
            _orderBL = p_orderBL;
            _storeFrontBL = p_storeFrontBL;
        }

        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Place Order Menu!");
            Console.WriteLine("Please choose an option to get started.");
            Console.WriteLine("[1] Get an order started");
            Console.WriteLine("[0] Go back to Main Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();
 
            switch(userInput) {
                case "1":
                    // for order, user needs customer name, customer email, and store name
                    Console.WriteLine();
                    Console.WriteLine("Please enter customer name: ");
                    string queryInput1 = Console.ReadLine();
                    Console.WriteLine("Please enter customer email: ");
                    string queryInput2 = Console.ReadLine();
                    Console.WriteLine("Please enter the store name: ");
                    string queryInput3 = Console.ReadLine();
                    Console.WriteLine();
                    // use a list to later input lineitem data into db
                    try {
                        List<LineItem> queryResult = _storeFrontBL.SearchStore(queryInput3);
                        foreach(var quantity in queryResult) {
                            quantity.Quantity = 0;
                        }
                        // use boolean to have a semi-infinite while loop
                        bool whileCounter = true;
                        double total = 0.00;
                        while(whileCounter) {
                            Console.Clear();
                            int counter = 1;
                            // foreach displays lineitem data
                            foreach(var query in queryResult) {
                                Console.WriteLine("[" + counter++ + "] : {0}  |  Price: {1}  |  Quantity: {2}", 
                                                    query.Name,
                                                    query.Price,
                                                    query.Quantity);
                            }
                            // user can keep adding quantity until order is finalized
                            Console.WriteLine("Choose a product to add, choose 9 to place order, or choose 0 to exit.");
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
                                // when customer is done, total price of order is added up
                                // information is sent to repository through orderbl object
                                    int storeID = 0;
                                    foreach(var enter in queryResult) {
                                        total += enter.Price * enter.Quantity;
                                        storeID = enter.LSId;
                                    }
                                    _orderBL.PlaceOrder(queryInput1,
                                                            queryInput2,
                                                            storeID,
                                                            total);
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
                        Console.WriteLine("Press Enter to go back to Place Order Menu");
                        Console.ReadLine();
                        return MenuType.PlaceOrderMenu;
                    }   
                    // catch block runs in case of an incorrect input
                    catch/*(InvalidOperationException)*/ {
                        Console.WriteLine("Input was invalid. Please press enter to try again.");
                        Console.ReadLine();
                        return MenuType.PlaceOrderMenu;
                    }
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrderMenu;
            }
        }
    }
}
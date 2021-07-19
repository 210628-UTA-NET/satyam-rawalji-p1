using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class SearchCustomerOrderHistoryMenu : IConsoleMenu {
        // use customerbl object to later send info to the repository for querying
        private ICustomerBL _customerBL;
        public SearchCustomerOrderHistoryMenu(ICustomerBL p_customerBL) {
            _customerBL = p_customerBL;
        }
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Search Customer Order Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Search for orders by customer name and email");
            Console.WriteLine("[0] Go back to Customer Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    // user needs to input name and email to get customer order history
                    Console.WriteLine();
                    Console.WriteLine("Please enter the customer name: ");
                    string queryInput1 = Console.ReadLine();
                    Console.WriteLine("Please enter the customer email: ");
                    string queryInput2 = Console.ReadLine();
                    Console.WriteLine();
                    
                    // try catch block used to handle some exceptions
                    try {
                        // if try block runs, orders are queried and placed in list<order>
                        List<Order> queryResult = _customerBL.SearchCustomerOrders(queryInput1, queryInput2);
                        Console.WriteLine("Found Customer!");
                        Console.WriteLine("Inventory: \n");
                        // use a foreach loop to display pertinent order informaiton
                        foreach(var query in queryResult) {
                            Console.WriteLine("Store: {0}  |  Date: {1}  |  Total purchase price: ${2}", 
                                                query.SName,
                                                query.Date,
                                                query.Total);
                        }
                        Console.WriteLine("Press Enter to go back to Customer Menu");
                        Console.ReadLine();
                        return MenuType.CustomerMenu;
                    }   
                    // if query doesnt work, redirect customer back to order history menu
                    catch/*(InvalidOperationException)*/ {
                        Console.WriteLine("Input was not found. Press press enter to try again.");
                        Console.ReadLine();
                        return MenuType.SearchCustomerOrderHistoryMenu;
                    }
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchCustomerOrderHistoryMenu;
            }
        }
    }
}
using System;

namespace StoreAppUI {
    public class CustomerMenu : IConsoleMenu {
        // menu user will interact with for all customer related inquiries
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Store App Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add a new customer");
            Console.WriteLine("[2] Search for a customer");
            Console.WriteLine("[3] Search for a customer's order history");
            Console.WriteLine("[0] Go back to Main Menu");
        }

        public MenuType UserChoice() {
            // get user input
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    return MenuType.AddCustomerMenu;
                case "2":
                    return MenuType.SearchCustomerMenu;
                case "3":
                    return MenuType.SearchCustomerOrderHistoryMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}
using System;

namespace StoreAppUI {
    // have main menu implement menu interface
    public class MainMenu : IConsoleMenu {
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Store App Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Go to the Customer options menu");
            Console.WriteLine("[2] Place an order for a customer");
            Console.WriteLine("[3] Go to the StoreFront options menu");
            Console.WriteLine("[0] Exit");
        }

        public MenuType UserChoice() {
            // use readline to get user's input
            string userInput = Console.ReadLine();

            // use switch case to handle different inputs, choice gets routed through factory menu file
            switch(userInput) {
                case "1":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.PlaceOrderMenu;
                case "3":
                    return MenuType.StoreFrontMenu;
                case "0":
                    return MenuType.Exit;
                // default case for in case user inputs a nonvalid case
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}
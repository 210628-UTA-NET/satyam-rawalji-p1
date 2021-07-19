using System;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class StoreFrontMenu : IConsoleMenu {
        public void ConsoleMenu() {
            // menu to deal with anything related to stores
            Console.WriteLine("Welcome to the Store Front Menu!");
            Console.WriteLine("Please choose an option to get started.");
            Console.WriteLine("[1] View Store Inventory");
            Console.WriteLine("[2] Replenish Store Inventory");
            Console.WriteLine("[3] View Store Order History");
            Console.WriteLine("[0] Go back to Main Menu");
        }
        public MenuType UserChoice() {
            // use user input to choose which menus to access
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    return MenuType.SearchStoreMenu;
                case "2":
                    return MenuType.ReplenishStoreMenu;
                case "3":
                    return MenuType.SearchStoreOrderHistoryMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreFrontMenu;
            }
        }
    }
}
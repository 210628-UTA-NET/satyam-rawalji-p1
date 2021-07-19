namespace StoreAppUI {
    // use enum for menu constants
    public enum MenuType {
        MainMenu,
        CustomerMenu,
        AddCustomerMenu,
        SearchCustomerMenu,
        PlaceOrderMenu,
        StoreFrontMenu,
        SearchStoreMenu,
        ReplenishStoreMenu,
        SearchStoreOrderHistoryMenu,
        SearchCustomerOrderHistoryMenu,
        Exit
    }

    // use a menu interface as base for all console menus
    // all menu objects will use this interface as a template
    public interface IConsoleMenu {
        /// <summary>
        /// ConsoleMenu will act as template for all menus use in app
        /// </summary>
        void ConsoleMenu();

        /// <summary>
        /// UserChoice will be template for handling all user inputs
        /// </summary>
        /// <returns> Will return value used to manuever through menu options</returns>
        MenuType UserChoice();
    }
}
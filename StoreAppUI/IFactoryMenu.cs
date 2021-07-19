namespace StoreAppUI {
    // have interface for factory design menus, called by program menu
    public interface IFactoryMenu {
        IConsoleMenu GetMenu(MenuType _menu);
    }
}
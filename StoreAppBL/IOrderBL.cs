using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL {
    public interface IOrderBL {
        // function with no implementation to prevent interface error
        Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total);
        List<Order> SearchCustomerOrders(string firstName, string lastName);

        List<Order> SearchStoreOrders(int storeId);
    }
}
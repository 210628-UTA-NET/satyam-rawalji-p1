using System;
using StoreAppModels;

namespace StoreAppBL {
    public interface IOrderBL {
        // function with no implementation to prevent interface error
        Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total);
    }
}
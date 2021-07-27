using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL {
    public interface IOrderBL {
        // function with no implementation to prevent interface error
        
        List<Order> SearchCustomerOrders(string firstName, string lastName);

        List<Order> SearchStoreOrders(int storeId);






        Order PlaceOrder(int storeId, int productId, int customerId, int quantitySold);
    }
}
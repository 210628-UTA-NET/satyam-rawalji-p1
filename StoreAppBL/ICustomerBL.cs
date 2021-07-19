using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL {    
    public interface ICustomerBL {
        // function declarations with no implementation
        Customer AddCustomer(Customer _customer);
        Customer SearchCustomer(string userEntry1, string userEntry2);
        List<Order> SearchCustomerOrders(string _customerName, string _customerEmail);
    }
}

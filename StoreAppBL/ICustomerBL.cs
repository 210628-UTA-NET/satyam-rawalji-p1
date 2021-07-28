using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL {    
    public interface ICustomerBL {
        // function declarations with no implementation
        Customer AddCustomer(Customer _customer);
        List<Customer> SearchCustomer(string firstName, string lastName);
        List<Customer> GetAllCustomers();
    }
}

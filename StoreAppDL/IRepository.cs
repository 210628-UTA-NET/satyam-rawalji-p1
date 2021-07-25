using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL
{
    // interface holds db functions that will be implemented in Repository.cs
    public interface IRepository {
        // list of function declarations
        Customer AddCustomer(Customer _customer);
        List<Customer> SearchCustomer(string firstName, string lastName);
        // adding search all customers for P1
        List<Customer> GetAllCustomers();
        Customer SearchCustomer(int _customerId);
        Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total);
        List<LineItem> SearchStore(string _storeName);
        List<LineItem> ReplenishStore(List<LineItem> _replenishStore);
        List<Order> SearchStoreOrders(string _storeName);
        List<Order> SearchCustomerOrders(string _customerName, string _customerEmail);
        List<StoreFront> GetAllStores();
    }    
}

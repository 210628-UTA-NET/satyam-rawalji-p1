using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL
{
    // interface holds db functions that will be implemented in Repository.cs
    public interface IRepository {
        // list of function declarations
        Customer AddCustomer(Customer _customer);
        // adding search all customers for P1
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomer(string firstName, string lastName);
        
        List<Order> SearchStoreOrders(int storeId);
        List<Order> SearchCustomerOrders(string firstName, string lastName);
        List<StoreFront> GetAllStores();
        List<Inventory> GetAllInventory(int _storeId);
        Inventory UpdateInventory(int _storeId, int _lineId, int newQuantity);


        Order PlaceOrder(int storeId, int productId, int customerId, int quantitySold);
    }    
}

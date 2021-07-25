using System;
using System.Collections.Generic;
using StoreAppModels;
using StoreAppDL;

namespace StoreAppBL {
    // customer business logic class extends the interface
    public class CustomerBL : ICustomerBL {
        // create repo variable to perform DB related functions
        private IRepository _repository;
        // use constructor to set repo variable that came from FactoryMenu.cs
        public CustomerBL(IRepository p_repository) {
            _repository = p_repository;
        }
        // function declarations with the DB logic in Repository.cs 
        public Customer AddCustomer(Customer _customer) {
            return _repository.AddCustomer(_customer);
        }
        
        public List<Customer> SearchCustomer(string firstName, string lastName) {
            return _repository.SearchCustomer(firstName, lastName);
        }

        public List<Order> SearchCustomerOrders(string _customerName, string _customerEmail) {
            return _repository.SearchCustomerOrders(_customerName, _customerEmail);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAllCustomers();
        }

        public Customer SearchCustomer(int _customerId)
        {
            return _repository.SearchCustomer(_customerId);
        }
    }
}
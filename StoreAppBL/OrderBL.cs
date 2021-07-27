using System;
using StoreAppModels;
using StoreAppDL;
using System.Collections.Generic;

namespace StoreAppBL {
    // class implements order business logic interface
    public class OrderBL : IOrderBL {
        // use repo variable to perform functions 
        private IRepository _repository;
        // constructor to initialize function call from FactoryMenu.cs
        public OrderBL(IRepository p_repository) {
            _repository = p_repository;
        }
        // function where implementation is defined in Repository.cs
        public Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total) {
            return _repository.PlaceOrder(_customerName, _customerEmail, _storeID, _total);
        }

        public List<Order> SearchCustomerOrders(string firstName, string lastName)
        {
            return _repository.SearchCustomerOrders(firstName, lastName);
        }

        public List<Order> SearchStoreOrders(int storeId)
        {
            return _repository.SearchStoreOrders(storeId);
        }
    }
}
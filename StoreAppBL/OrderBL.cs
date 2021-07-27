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
        

        public List<Order> SearchCustomerOrders(string firstName, string lastName)
        {
            return _repository.SearchCustomerOrders(firstName, lastName);
        }

        public List<Order> SearchStoreOrders(int storeId)
        {
            return _repository.SearchStoreOrders(storeId);
        }






        public Order PlaceOrder(int storeId, int productId, int customerId, int quantitySold)
        {
            return _repository.PlaceOrder(storeId, productId, customerId, quantitySold);
        }
    }
}
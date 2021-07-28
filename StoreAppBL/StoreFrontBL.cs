using System;
using System.Collections.Generic;
using StoreAppModels;
using StoreAppDL;

namespace StoreAppBL {
    // storefrontbl inherits functions not implemented in storefrontbl interface
    public class StoreFrontBL : IStoreFrontBL {
        // declare repo variable to run functions in Repository.cs
        private readonly IRepository _repository;

        // constructor to initialize variable pass from FactoryMenu
        public StoreFrontBL(IRepository p_repository) {
            _repository = p_repository;
        }

        // functions whose logic will be implemented in Repository.cs
        public List<StoreFront> GetAllStores()
        {
            return _repository.GetAllStores();
        }
    }
}
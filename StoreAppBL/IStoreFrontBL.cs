using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    // interface for storefront business logic with no implementation
    public interface IStoreFrontBL {
        // functions to be inherited by storefront bl
        List<LineItem> SearchStore(string _storeName);
        List<LineItem> ReplenishStore(List<LineItem> _replenishStore);
        
        List<StoreFront> GetAllStores();
    }
}
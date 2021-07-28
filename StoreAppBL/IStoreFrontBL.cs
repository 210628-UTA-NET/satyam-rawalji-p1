using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    // interface for storefront business logic with no implementation
    public interface IStoreFrontBL {

        // functions to be inherited by storefront bl
        List<StoreFront> GetAllStores();
    }
}
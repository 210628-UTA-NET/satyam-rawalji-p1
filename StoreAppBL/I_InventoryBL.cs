using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppBL
{
    public interface I_InventoryBL
    {
        List<Inventory> GetAllInventory(int _storeId);
    }
}

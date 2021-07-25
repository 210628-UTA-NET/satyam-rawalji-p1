using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class InventoryBL : I_InventoryBL
    {
        // declare repo variable to run functions in Repository.cs
        private IRepository _repository;
        // constructor to initialize variable pass from FactoryMenu
        public InventoryBL(IRepository p_repository)
        {
            _repository = p_repository;
        }

        public List<Inventory> GetAllInventory(int _storeId)
        {
            return _repository.GetAllInventory(_storeId);
        }

        public Inventory UpdateInventory(int _storeId, int _lineId, int newQuantity)
        {
            return _repository.UpdateInventory(_storeId, _lineId, newQuantity);
        }
    }
}

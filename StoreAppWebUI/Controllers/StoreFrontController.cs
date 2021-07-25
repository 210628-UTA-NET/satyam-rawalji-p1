using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppBL;
using StoreAppWebUI.Models;

namespace StoreAppWebUI.Controllers
{
    public class StoreFrontController : Controller
    {
        private IStoreFrontBL _storeFrontBL;
        private I_InventoryBL _inventoryBL;
        /// <summary>
        /// Using a constructor for dependency injection, create bl variable and pass through ctor
        /// </summary>
        /// <param name="p_storeFrontBL"></param>
        public StoreFrontController (IStoreFrontBL p_storeFrontBL, I_InventoryBL p_inventoryBL)
        {
            _storeFrontBL = p_storeFrontBL;
            _inventoryBL = p_inventoryBL;
        }
        /// <summary>
        /// access repository through bl layer and retrieve all stores in db
        /// </summary>
        /// <returns>returns list of all stores</returns>
        public IActionResult Index()
        {
            return View(
                _storeFrontBL.GetAllStores()
                .Select(store => new StoreFrontVM(store))
                .ToList()
            );
        }

        public IActionResult Inventory(int storeId)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    return View(
                        _inventoryBL.GetAllInventory(storeId)
                        .Select(inv => new InventoryVM(inv))
                        .ToList()
                    );
                }
            }
            // block to catch any exceptions
            catch (InvalidOperationException)
            {
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreAppBL;
using StoreAppWebUI.Models;

namespace StoreAppWebUI.Controllers
{
    public class StoreFrontController : Controller
    {
        // business logic variables
        private IStoreFrontBL _storeFrontBL;
        private I_InventoryBL _inventoryBL;
        private readonly ILogger<StoreFrontController> _logger;

        /// <summary>
        /// Using a constructor for dependency injection, create bl variable and pass through ctor
        /// </summary>
        /// <param name="p_storeFrontBL"></param>
        public StoreFrontController (IStoreFrontBL p_storeFrontBL, I_InventoryBL p_inventoryBL, ILogger<StoreFrontController> logger)
        {
            _storeFrontBL = p_storeFrontBL;
            _inventoryBL = p_inventoryBL;
            _logger = logger;
        }

        /// <summary>
        /// access repository through bl layer and retrieve all stores in db
        /// </summary>
        /// <returns>returns list of all stores</returns>
        public IActionResult Index()
        {
            _logger.LogInformation("End user should see a list of all the stores.");
            return View(
                _storeFrontBL.GetAllStores()
                .Select(store => new StoreFrontVM(store))
                .ToList()
            );
        }

        /// <summary>
        /// Inventory takes a parameter and returns the inventory for the store associated with the id parameter
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public IActionResult Inventory(int storeId)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("End user should see inventory of an associated store");
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
                _logger.LogInformation("This shows the catch block being used if inventory access didnt work");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }

        /// <summary>
        /// Just view of inventory amount and option to update amount
        /// </summary>
        /// <returns>Should redirect from overloaded function into a confirmation page</returns>
        public IActionResult Replenish()
        {
            _logger.LogInformation("End user should be on the replenish inventory page");
            return View();
        }

        /// <summary>
        /// Passes inventory viewmodel to function that updates db
        /// </summary>
        /// <param name="invVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Replenish(InventoryVM invVM)
        {
            _logger.LogInformation("End user should be redirected to page which controls amount of inventory to replenish");
            return RedirectToAction("ReplenishInventory", 
                new { storeId = invVM.StoreId, lineId = invVM.LineItemId, newQuantity = invVM.QuantityHeld});
        }

        /// <summary>
        /// Updates db and then shows a confirmation page, check console to make sure catch block wasnt used
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="lineId"></param>
        /// <param name="newQuantity"></param>
        /// <returns> reteurns end user to confirmation page, and option to go back to storefront menu </returns>
        public IActionResult ReplenishInventory(int storeId, int lineId, int newQuantity)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    _inventoryBL.UpdateInventory(storeId, lineId, newQuantity);
                    _logger.LogInformation("Inventory amount should be updated if this shows?");
                    return View();
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                _logger.LogInformation("This shows the catch block being used if inventory access didnt work");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }
    }
}

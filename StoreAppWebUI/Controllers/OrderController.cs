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
    public class OrderController : Controller
    {
        // variables for business logic 
        private ICustomerBL _customerBL;
        private IStoreFrontBL _storeFrontBL;
        private I_InventoryBL _inventoryBL;
        private IOrderBL _orderBL;
        private readonly ILogger<OrderController> _logger;

        /// <summary>
        /// Using a constructor for dependency injection, create bl variable and pass through ctor
        /// </summary>
        public OrderController(ICustomerBL p_customerBL, IStoreFrontBL p_storeFrontBL, I_InventoryBL p_inventoryBL, 
                                IOrderBL p_orderBL, ILogger<OrderController> logger)
        {
            _customerBL = p_customerBL;
            _storeFrontBL = p_storeFrontBL;
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
            _logger = logger;
        }

        /// <summary>
        /// User should see the Orders Home page
        /// </summary>
        /// <returns> Page mainly for searching orders by store or customer</returns>
        public IActionResult Index()
        {
            _logger.LogInformation("End user should be seeing Order home page");
            return View();
        }

        /// <summary>
        /// User should see page to search order history by customer
        /// </summary>
        /// <returns></returns>
        public IActionResult ByCustomer()
        {
            _logger.LogInformation("End user should be page of searching for a customer's order history");
            return View();
        }

        /// <summary>
        /// Use customer name to search order history, sortedOrder variable allows sort by ascending or descending
        /// </summary>
        /// <param name="custVM"></param>
        /// <returns> redirects to order history of a customer if successful </returns>
        [HttpPost]
        public IActionResult ByCustomer(CustomerVM custVM)
        {
            _logger.LogInformation("End user should be redirected to order history page for a searched customer");
            return RedirectToAction("CustomerOrders", new { firstName = custVM.FirstName, lastName = custVM.LastName, sortedOrder = "" });
        }

        // handles the sorting on the orders page, along with presenting data
        public IActionResult CustomerOrders(string firstName, string lastName, string sortOrder)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    ViewBag.DateSort = String.IsNullOrEmpty(sortOrder) ? "DateDesc" : "";
                    ViewBag.PriceSort = sortOrder == "Price" ? "PriceDesc" : "Price";

                    var list = _orderBL.SearchCustomerOrders(firstName, lastName)
                        .Select(o => new OrderVM(o))
                        .ToList();

                    var sorted = from s in list
                                 select s;

                    switch (sortOrder)
                    {
                        case "DateDesc":
                            sorted = sorted.OrderByDescending(s => s.Date);
                            break;
                        case "":
                            sorted = sorted.OrderBy(s => s.Date);
                            break;
                        case "PriceDesc":
                            sorted = sorted.OrderByDescending(s => s.Total);
                            break;
                        default:
                            sorted = sorted.OrderBy(s => s.Total);
                            break;
                    }

                    _logger.LogInformation("End user should be seeing customer order history");
                    return View(sorted);
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                _logger.LogInformation("Catch block was used when trying to see customer order history");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }

        /// <summary>
        /// Customer can choose to see a store's order history
        /// </summary>
        /// <returns> view of list of stores in db </returns>
        public IActionResult ByStore()
        {
            _logger.LogInformation("End user should be seeing list of all stores in db");
            return View(
                _storeFrontBL.GetAllStores()
                .Select(store => new StoreFrontVM(store))
                .ToList()
            );
        }

        /// <summary>
        /// Customer should be seeing order history of selected store
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="sortOrder"></param>
        /// <returns> returns view of a selected store's order history </returns>
        public IActionResult StoreOrders(int storeId, string sortOrder)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    ViewBag.DateSort = String.IsNullOrEmpty(sortOrder) ? "DateDesc" : "";
                    ViewBag.PriceSort = sortOrder == "Price" ? "PriceDesc" : "Price";

                    var list = _orderBL.SearchStoreOrders(storeId)
                        .Select(o => new OrderVM(o))
                        .ToList();

                    var sorted = from s in list
                                 select s;

                    switch (sortOrder)
                    {
                        case "DateDesc":
                            sorted = sorted.OrderByDescending(s => s.Date);
                            break;
                        case "":
                            sorted = sorted.OrderBy(s => s.Date);
                            break;
                        case "PriceDesc":
                            sorted = sorted.OrderByDescending(s => s.Total);
                            break;
                        default:
                            sorted = sorted.OrderBy(s => s.Total);
                            break;
                    }

                    _logger.LogInformation("End user should be seeing list of order history for a store");
                    return View(sorted);
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                _logger.LogInformation("Catch block was used when trying to see a store's order history");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }
    }
}

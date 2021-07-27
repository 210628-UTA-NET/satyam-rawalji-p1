using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppBL;
using StoreAppWebUI.Models;

namespace StoreAppWebUI.Controllers
{
    public class OrderController : Controller
    {
        private ICustomerBL _customerBL;
        private IStoreFrontBL _storeFrontBL;
        private I_InventoryBL _inventoryBL;
        private IOrderBL _orderBL;

        /// <summary>
        /// Using a constructor for dependency injection, create bl variable and pass through ctor
        /// </summary>
        public OrderController(ICustomerBL p_customerBL, IStoreFrontBL p_storeFrontBL, I_InventoryBL p_inventoryBL, IOrderBL p_orderBL)
        {
            _customerBL = p_customerBL;
            _storeFrontBL = p_storeFrontBL;
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ByCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ByCustomer(CustomerVM custVM)
        {
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

                    return View(sorted);
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }

        public IActionResult ByStore()
        {
            return View(
                _storeFrontBL.GetAllStores()
                .Select(store => new StoreFrontVM(store))
                .ToList()
            );
        }

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

                    return View(sorted);
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }
    }
}

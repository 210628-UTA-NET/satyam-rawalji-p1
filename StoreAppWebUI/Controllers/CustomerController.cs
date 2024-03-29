﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreAppBL;
using StoreAppModels;
using StoreAppWebUI.Models;

namespace StoreAppWebUI.Controllers
{
    public class CustomerController : Controller
    {
        // business logic variables
        private readonly ICustomerBL _customerBL;
        private readonly IStoreFrontBL _storeFrontBL;
        private readonly I_InventoryBL _inventoryBL;
        private readonly IOrderBL _orderBL;
        private readonly ILogger<CustomerController> _logger;

        /// <summary>
        /// Using a constructor for dependency injection, create bl variable and pass through ctor
        /// </summary>
        public CustomerController(ICustomerBL p_customerBL, IStoreFrontBL p_storeFrontBL, I_InventoryBL p_inventoryBL, 
                                   IOrderBL p_orderBL, ILogger<CustomerController> logger)
        {
            _customerBL = p_customerBL;
            _storeFrontBL = p_storeFrontBL;
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
            _logger = logger;
        }

        /// <summary>
        /// Use customer business logic class to query database for all customers
        /// </summary>
        /// <returns> returns a list of all customers in the database </returns>
        public IActionResult Index()
        {
            _logger.LogInformation("End user should be seeing list of all customers in db");
            // model binding between view and model
            return View(
                _customerBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
            );
        }

        /// <summary>
        /// Use customer business logic class to insert a new customer into db
        /// </summary>
        /// <returns> returns View object </returns>
        public IActionResult Create()
        {
            _logger.LogInformation("End user should be on create customer page");
            return View();
        }

        /// <summary>
        /// This create function will work for a post http request
        /// </summary>
        /// <returns> returns View object </returns>
        [HttpPost]
        public IActionResult Create(CustomerVM custVM)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if(ModelState.IsValid)
                {
                    _customerBL.AddCustomer(new Customer
                    {
                        FirstName = custVM.FirstName,
                        MiddleName = custVM.MiddleName,
                        LastName = custVM.LastName,
                        Address = custVM.Address,
                        City = custVM.City,
                        State = custVM.State,
                        ZipCode = custVM.ZipCode,
                        Email = custVM.Email,
                        PhoneNumber = custVM.PhoneNumber,
                        IsManager = custVM.IsManager
                    });

                    _logger.LogInformation("New customer should be added to db, and end user redirected to Customer Home Page");
                    // use redirect to pass user to another page
                    // Other page in this case is index.cshtml for Customer controller
                    return RedirectToAction(nameof(Index));
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                _logger.LogInformation("This shows the catch block was used when creating a customer");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }

        /// <summary>
        /// Function brings up view of search customer page
        /// </summary>
        /// <returns> webpage giving customer option to search for a customer </returns>
        public IActionResult Search()
        {
            _logger.LogInformation("End user should be seeing search customer option");
            return View();
        }

        /// <summary>
        /// Overloaded function redirects customer to options page with customer viewmodel as parameter
        /// </summary>
        /// <param name="custVM"></param>
        /// <returns> return options page for a certain customer </returns>
        [HttpPost]
        public IActionResult Search(CustomerVM custVM)
        {
            return RedirectToAction("Options", new { firstName = custVM.FirstName, lastName = custVM.LastName });
        }

        /// <summary>
        /// If customer with passed parameters exists, tuple should show on window
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns> returns a tuple of searched customer </returns>
        public IActionResult Options(string firstName, string lastName)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("End user should be seeing tuple of searched customer");
                    return View(
                        _customerBL.SearchCustomer(firstName, lastName)
                        .Select(cust => new CustomerVM(cust))
                        .ToList());
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                _logger.LogInformation("Catch block was used when searching for a customer");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }

        /// <summary>
        /// Select store will allow customer to choose store to order from
        /// </summary>
        /// <returns>  </returns>
        public IActionResult SelectStore(int p_id)
        {
            _logger.LogInformation("End user should be seeing list of all stores to make an order from");
            return View(
                _storeFrontBL.GetAllStores()
                .Select(cust => new StoreFrontVM(cust))
                .ToList()
            );
        }

        /// <summary>
        /// Order page will come from customer select and allow them to make a purchase
        /// </summary>
        /// <param name="p_id"></param>
        /// <param name="p_storeId"></param>
        /// <returns></returns>
        public IActionResult Order(int p_id, int p_storeId)
        {
            return View(
                _inventoryBL.GetAllInventory(p_storeId)
                .Select(inv => new InventoryVM(inv))
                .ToList()
            ); 
        }

        /// <summary>
        /// This page allows us to choose the amount of an item to order
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="customerId"></param>
        /// <param name="productId"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="name"></param>
        /// <returns> will return you to orderplaced function </returns>
        public IActionResult OrderAmount(int storeId, int customerId, int productId, double price, int quantity, string name)
        {
            ViewBag.store = storeId;
            ViewBag.customer= customerId;
            ViewBag.product = productId;
            ViewBag.quantity = quantity;
            ViewBag.name = name;
            ViewBag.price = price;
            return View();
        }

        /// <summary>
        /// Will place order into db
        /// </summary>
        /// <param name="ordVM"></param>
        /// <returns> will return you to a page confirming purchase, then can go to Index </returns>
        public IActionResult OrderPlaced(OrderVM ordVM)
        {
            // use try catch for validation
            try
            {
                // model state to make sure current model from ui is valid
                if (ModelState.IsValid)
                {
                    _orderBL.PlaceOrder(ordVM.StoreId, ordVM.LineItemId, ordVM.CustomerId, ordVM.QuantitySold);

                    _logger.LogInformation("New order should be added to db, and end user redirected to Customer Home Page");
                    // use redirect to pass user to another page
                    // Other page in this case is index.cshtml for Customer controller
                    return RedirectToAction(nameof(Index));
                }
            }
            // block to catch any exceptions
            catch (Exception)
            {
                _logger.LogInformation("This shows the catch block was used when creating a customer");
                // return view if try block doesnt work
                return View();
            }
            // in a sense, the finally block if try or catch arent used
            return View();
        }
    }
}

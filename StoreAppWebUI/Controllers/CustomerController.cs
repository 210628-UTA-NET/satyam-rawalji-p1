using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppBL;
using StoreAppModels;
using StoreAppWebUI.Models;

namespace StoreAppWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        /// <summary>
        /// Using a constructor for dependency injection, create bl variable and pass through ctor
        /// </summary>
        public CustomerController(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        /// <summary>
        /// Use customer business logic class to query database for all customers
        /// </summary>
        /// <returns> returns a list of all customers in the database </returns>
        public IActionResult Index()
        {
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
                        PhoneNumber = custVM.PhoneNumber
                    });

                    // use redirect to pass user to another page
                    // Other page in this case is index.cshtml for Customer controller
                    return RedirectToAction(nameof(Index));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppBL;
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
        public IActionResult Index()
        {
            // model binding between view and model
            return View(
                _customerBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
            );
        }
    }
}

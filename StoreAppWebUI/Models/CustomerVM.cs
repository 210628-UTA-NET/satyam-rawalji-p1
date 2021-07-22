using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppWebUI.Models
{
    public class CustomerVM
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public CustomerVM()
        { }
        /// <summary>
        /// This constructor will take a Customer object to initialize the values from query
        /// </summary>
        public CustomerVM(Customer p_customer)
        {
            Id = p_customer.Id;
            FirstName = p_customer.FirstName;
            MiddleName = p_customer.MiddleName;
            LastName = p_customer.LastName;
            Address = p_customer.Address;
            City = p_customer.City;
            State = p_customer.State;
            ZipCode = p_customer.ZipCode;
            Email = p_customer.Email;
            PhoneNumber = p_customer.PhoneNumber;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

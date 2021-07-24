using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            IsManager = p_customer.IsManager;
        }

        // will use data annotations to validate correct data is entered
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsManager { get; set; }
    }
}

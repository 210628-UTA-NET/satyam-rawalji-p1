using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StoreAppModels
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        public Customer() {}
        [Required]
        public int Id { get; set; }
        // borrowed from Restaurantreview to see how the testing would work
        [Required]
        public string FirstName 
        {
            get
            {
                return firstName;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    //This will throw an exception when first name entry has anything but letters
                    throw new Exception("Name entry should only have letters.");
                }

                firstName = value;
            }
        }
        public string MiddleName { get; set; }
        [Required]
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    //This will throw an exception when last name entry has anything but letters
                    throw new Exception("Name entry should only have letters.");
                }

                lastName = value;
            }
        }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public bool IsManager { get; set; }
    }
}

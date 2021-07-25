using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppWebUI.Models
{
    public class StoreFrontVM
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public StoreFrontVM()
        { }
        /// <summary>
        /// This constructor will take a StoreFront object to initialize the values from query
        /// </summary>
        public StoreFrontVM(StoreFront p_storeFront)
        {
            Id = p_storeFront.Id;
            Name = p_storeFront.Name;
            Address = p_storeFront.Address;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

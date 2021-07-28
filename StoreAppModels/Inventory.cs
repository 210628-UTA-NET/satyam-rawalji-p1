using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppModels
{
    public class Inventory
    {
        private double _price;
        public Inventory() { }
        [Required]
        public int Id { get; set; }
        [Required]
        public int LineItemId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity should be a positive number")]
        public int QuantityHeld { get; set; }
        [Required]
        public double Price { get { return _price; } set { _price = (double) value; } }
        public LineItem LineItem { get; set; }
        public StoreFront StoreFront { get; set; }
    }
}

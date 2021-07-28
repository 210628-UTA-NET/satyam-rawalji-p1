using System;
using System.ComponentModel.DataAnnotations;

namespace StoreAppModels {
    public class Order {
        public Order() {}
        [Required]
        public int Id { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int LineItemId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity should be a positive number")]
        public int QuantitySold { get; set; }
        [Required]
        public double Total {get;set;}
        public StoreFront StoreFront { get; set; }
        public LineItem LineItem { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date {get;set;}
    }
}
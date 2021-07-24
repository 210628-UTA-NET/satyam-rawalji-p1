using System;

namespace StoreAppModels {
    public class Order {
        public Order() {}
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int LineItemId { get; set; }
        public int CustomerId { get; set; }
        public int QuantitySold { get; set; }
        public double Total {get;set;}
        public DateTime Date {get;set;}
    }
}
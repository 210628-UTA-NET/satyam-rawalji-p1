using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppWebUI.Models
{
    public class OrderVM
    {
        public OrderVM() { }
        public OrderVM(Order p_order)
        {
            Id = p_order.Id;
            StoreId = p_order.StoreId;
            LineItemId = p_order.LineItemId;
            CustomerId = p_order.CustomerId;
            QuantitySold = p_order.QuantitySold;
            Total = p_order.Total;
            StoreFront = new StoreFront()
            {
                Id = p_order.StoreFront.Id,
                Name = p_order.StoreFront.Name,
                Address = p_order.StoreFront.Address
            };
            LineItem = new LineItem()
            {
                Id = p_order.LineItem.Id,
                Name = p_order.LineItem.Name
            };
            Customer = new Customer()
            {
                Id = p_order.Customer.Id,
                FirstName = p_order.Customer.FirstName,
                MiddleName = p_order.Customer.MiddleName,
                LastName = p_order.Customer.LastName,
                Address = p_order.Customer.Address,
                City = p_order.Customer.City,
                State = p_order.Customer.State,
                ZipCode = p_order.Customer.ZipCode,
                Email = p_order.Customer.Email,
                PhoneNumber = p_order.Customer.PhoneNumber,
                IsManager = p_order.Customer.IsManager
            };
        }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int LineItemId { get; set; }
        public int CustomerId { get; set; }
        public int QuantitySold { get; set; }
        public double Total { get; set; }
        public StoreFront StoreFront { get; set; }
        public LineItem LineItem { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
    }
}

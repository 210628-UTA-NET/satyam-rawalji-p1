using System;
using System.Collections.Generic;
using StoreAppModels;
using System.Linq;

namespace StoreAppDL {
    // Repository implements repository interface
    public class Repository : IRepository {
        // create dbcontext variable to run queries
        private StoreAppDBContext _context;
        // use Repository constructor to use variable passed from FactoryMenu.cs
        public Repository(StoreAppDBContext p_context) {
            // dependency injection
            _context = p_context;
        }
        // adds customer to db
        public StoreAppModels.Customer AddCustomer(StoreAppModels.Customer p_customer) {
            _context.Customers.Add(p_customer);
            _context.SaveChanges();
            return p_customer;
        }
        // searches for customer based on name and email
        public StoreAppModels.Customer SearchCustomer(string userEntry1, string userEntry2) {
            StoreAppModels.Customer queryCustomer = new StoreAppModels.Customer();
            /*var customer = _context.Customers.Single(person => person.CName == userEntry1 && person.CEmail == userEntry2);
            queryCustomer.Name = customer.CName;
            queryCustomer.Email = customer.CEmail;
            queryCustomer.Address = customer.CAddress;
            queryCustomer.PhoneNumber = customer.CPhoneNumber;
            */

            return queryCustomer;
        }
        // places order based on customer and store id
        public StoreAppModels.Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total) {
            /*var customer = (from c in _context.Customers
                            where c.CName == _customerName && c.CEmail == _customerEmail
                            select new StoreAppModels.Customer() {
                                CId = c.CId
                            }).Single();
            _context.Orders.Add(new StoreAppDL.Entities.Order{
                OCId = customer.CId,
                OSId = _storeID,
                OTotal = _total
            });
            _context.SaveChanges();*/
            return new StoreAppModels.Order();
        }
        // searches for store and returns inventory
        public List<StoreAppModels.LineItem> SearchStore(string _storeName) {
            /*return (from li in _context.LineItems
                    join p in _context.Products on li.LPId equals p.PId
                    join sf in _context.StoreFronts on li.LSId equals sf.SId
                    where sf.SName == _storeName
                    select new StoreAppModels.LineItem() {
                        LId = li.LId,
                        LSId = (int)li.LSId,
                        Name = p.PName,
                        Price = p.PPrice,
                        Quantity = li.LQuantity
                    }).ToList();*/
            return new List<LineItem>();
        }
        // replenishes store inventory if user chooses so
        public List<StoreAppModels.LineItem> ReplenishStore(List<StoreAppModels.LineItem> _replenishStore) {
            /*foreach(var product in _replenishStore) {
                var item = _context.LineItems.Single(li => li.LId == product.LId);
                item.LQuantity = product.Quantity;
                _context.SaveChanges();
            }*/
            return _replenishStore;
        }
        // searches db for orders linked to user-chosen store
        public List<StoreAppModels.Order> SearchStoreOrders(string _storeName) {
            /*return (from sf in _context.StoreFronts
                    join o in _context.Orders on sf.SId equals o.OSId
                    where sf.SName == _storeName
                    select new StoreAppModels.Order() {
                        CId = o.OCId,
                        SId = sf.SId,
                        Total = Math.Round((double)o.OTotal,2),
                        Date = (DateTime)o.OOrderDate
                    }).OrderByDescending(date => date.Date)
                    .ToList();
            */
            return new List<Order>();
        }
        // searches db for orders linked to user-chosen customer
        public List<StoreAppModels.Order> SearchCustomerOrders(string _customerName, string _customerEmail) {
            /*return (from c in _context.Customers
                    join o in _context.Orders on c.CId equals o.OCId
                    join s in _context.StoreFronts on o.OSId equals s.SId
                    where c.CName == _customerName && c.CEmail == _customerEmail
                    select new StoreAppModels.Order() {
                        CId = o.OCId,
                        SId = o.OSId,
                        SName = s.SName,
                        Total = Math.Round((double)o.OTotal,2),
                        Date = (DateTime)o.OOrderDate
                    }).OrderByDescending(date => date.Date)
                    .ToList();
            */
            return new List<Order>();
        }

        // adding search all customers for P1
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }
    }
}
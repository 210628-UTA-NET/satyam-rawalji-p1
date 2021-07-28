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
        public Customer AddCustomer(Customer p_customer) {
            _context.Customers.Add(p_customer);
            _context.SaveChanges();
            return p_customer;
        }

        // searches for customer based on first and last name
        public List<Customer> SearchCustomer(string firstName, string lastName) {
            return _context.Customers
                .Select(cust => cust)
                .Where(cust => cust.FirstName == firstName && cust.LastName == lastName)
                .ToList();
        }

        
        // adding search all customers for P1
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }

        // adding search all stores for p1
        public List<StoreFront> GetAllStores()
        {
            return _context.StoreFronts.Select(store => store).ToList();
        }

        // retuns all the inventory based on the entered store id
        public List<Inventory> GetAllInventory(int _storeId)
        {
            return (from i in _context.Inventories
                    join li in _context.LineItems on i.LineItemId equals li.Id
                    join sf in _context.StoreFronts on i.StoreId equals sf.Id
                    where i.StoreId == _storeId
                    select new Inventory()
                    {
                        Id = i.Id,
                        LineItemId = i.LineItemId,
                        StoreId = i.StoreId,
                        QuantityHeld = i.QuantityHeld,
                        Price = i.Price,
                        LineItem = new LineItem()
                        {
                            Id = li.Id,
                            Name = li.Name
                        },
                        StoreFront = new StoreFront()
                        {
                            Id = sf.Id,
                            Name = sf.Name,
                            Address = sf.Address
                        }
                    }).ToList();
        }

        // updates inventory based on both store and lineitem id (which composite in inventory)
        public Inventory UpdateInventory(int _storeId, int _lineId, int newQuantity)
        {
            Inventory inv = _context.Inventories.Single(i => i.StoreId == _storeId && i.LineItemId == _lineId);
            inv.QuantityHeld = newQuantity;
            _context.Inventories.Update(inv);

            _context.SaveChanges();
            return new Inventory();
        }

        // searches db for orders linked to user-chosen customer
        public List<Order> SearchCustomerOrders(string firstName, string lastName)
        {
            return (from o in _context.Orders
                    join s in _context.StoreFronts on o.StoreId equals s.Id 
                    join li in _context.LineItems on o.LineItemId equals li.Id
                    join c in _context.Customers on o.CustomerId equals c.Id
                    where c.FirstName == firstName && c.LastName == lastName
                    select new Order()
                    {
                        Id = o.Id,
                        StoreId = o.StoreId,
                        LineItemId = o.LineItemId,
                        CustomerId = o.CustomerId,
                        QuantitySold = o.QuantitySold,
                        Total = o.Total,
                        Date = Convert.ToDateTime(o.Date).ToLocalTime(),
                        StoreFront = new StoreFront()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Address = s.Address
                        },
                        LineItem = new LineItem()
                        {
                            Id = li.Id,
                            Name = li.Name
                        },
                        Customer = new Customer()
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            MiddleName = c.MiddleName,
                            LastName = c.LastName,
                            Address = c.Address,
                            City = c.City,
                            State = c.State,
                            ZipCode = c.ZipCode,
                            Email = c.Email,
                            PhoneNumber = c.PhoneNumber,
                            IsManager = c.IsManager
                        }
                    }
            ).ToList();
        }


        // searches db for orders linked to user-chosen store
        public List<Order> SearchStoreOrders(int storeId)
        {
            return (from o in _context.Orders
                    join s in _context.StoreFronts on o.StoreId equals s.Id
                    join li in _context.LineItems on o.LineItemId equals li.Id
                    join c in _context.Customers on o.CustomerId equals c.Id
                    where s.Id == storeId
                    select new Order()
                    {
                        Id = o.Id,
                        StoreId = o.StoreId,
                        LineItemId = o.LineItemId,
                        CustomerId = o.CustomerId,
                        QuantitySold = o.QuantitySold,
                        Total = o.Total,
                        Date = Convert.ToDateTime(o.Date).ToLocalTime(),
                        StoreFront = new StoreFront()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Address = s.Address
                        },
                        LineItem = new LineItem()
                        {
                            Id = li.Id,
                            Name = li.Name
                        },
                        Customer = new Customer()
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            MiddleName = c.MiddleName,
                            LastName = c.LastName,
                            Address = c.Address,
                            City = c.City,
                            State = c.State,
                            ZipCode = c.ZipCode,
                            Email = c.Email,
                            PhoneNumber = c.PhoneNumber,
                            IsManager = c.IsManager
                        }
                    }
            ).ToList();
        }

        // places order based on customer and store id
        public Order PlaceOrder(int storeId, int productId, int customerId, int quantitySold)
        {
            var price = (from inv in _context.Inventories
                         where inv.LineItemId == productId && inv.StoreId == storeId
                         select inv.Price);
            double total = Convert.ToDouble(price) * quantitySold;

            Order newOrder = new Order()
            {
                StoreId = storeId,
                LineItemId = productId,
                CustomerId = customerId, 
                QuantitySold = quantitySold,
                Total = total,
                Date = DateTime.Now
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            Inventory inven = _context.Inventories.Single(i => i.StoreId == storeId && i.LineItemId == productId);
            inven.QuantityHeld -= quantitySold;
            _context.Inventories.Update(inven);
         
            _context.SaveChanges();
            return new Order();
        }
    }
}
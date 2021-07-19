using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public string CEmail { get; set; }
        public string CPhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

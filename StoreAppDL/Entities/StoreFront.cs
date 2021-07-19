using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDL.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            LineItems = new HashSet<LineItem>();
            Orders = new HashSet<Order>();
        }

        public int SId { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

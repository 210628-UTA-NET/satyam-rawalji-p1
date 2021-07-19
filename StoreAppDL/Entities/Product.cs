using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int PId { get; set; }
        public string PName { get; set; }
        public double PPrice { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}

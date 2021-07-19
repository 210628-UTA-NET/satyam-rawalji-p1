using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDL.Entities
{
    public partial class Order
    {
        public int OId { get; set; }
        public int OSId { get; set; }
        public int OCId { get; set; }
        public double? OTotal { get; set; }
        public DateTime? OOrderDate { get; set; }

        public virtual Customer OC { get; set; }
        public virtual StoreFront OS { get; set; }
    }
}

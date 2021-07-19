using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDL.Entities
{
    public partial class LineItem
    {
        public int LId { get; set; }
        public int LPId { get; set; }
        public int LQuantity { get; set; }
        public int? LSId { get; set; }

        public virtual Product LP { get; set; }
        public virtual StoreFront LS { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppWebUI.Models
{
    public class EverythingVM
    {
        public EverythingVM() { }
        public CustomerVM CustomerVM { get; set; }
        public InventoryVM InventoryVM { get; set; }
        public StoreFrontVM StoreFrontVM { get; set; }
        public LineItemVM LineItemVM { get; set; }
    }
}

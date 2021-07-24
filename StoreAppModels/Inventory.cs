﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppModels
{
    public class Inventory
    {
        public Inventory() { }
        public int Id { get; set; }
        public int LineItemId { get; set; }
        public int StoreId { get; set; }
        public int QuantityHeld { get; set; }
        public double Price { get; set; }
    }
}

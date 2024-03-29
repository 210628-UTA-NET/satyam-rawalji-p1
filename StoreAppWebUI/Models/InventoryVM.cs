﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppWebUI.Models
{
    public class InventoryVM
    {
        /// <summary>
        /// Blank constructor for InventoryVM object
        /// </summary>
        public InventoryVM() { }

        /// <summary>
        /// use inventory object to instantiate an InventoryVM object
        /// </summary>
        /// <param name="p_inventory"></param>
        public InventoryVM(Inventory p_inventory)
        {
            Id = p_inventory.Id;
            LineItemId = p_inventory.LineItemId;
            StoreId = p_inventory.StoreId;
            QuantityHeld = p_inventory.QuantityHeld;
            Price = p_inventory.Price;
            LineItem = new LineItem()
            {
                Id = p_inventory.LineItem.Id,
                Name = p_inventory.LineItem.Name
            };
            StoreFront = new StoreFront()
            {
                Id = p_inventory.StoreFront.Id,
                Name = p_inventory.StoreFront.Name,
                Address = p_inventory.StoreFront.Address
            };
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public int LineItemId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int QuantityHeld { get; set; }
        [Required]
        public double Price { get; set; }
        public LineItem LineItem { get; set; }
        public StoreFront StoreFront { get; set; }
    }
}

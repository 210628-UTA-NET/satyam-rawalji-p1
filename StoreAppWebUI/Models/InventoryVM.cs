using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM(Inventory p_inventory)
        {
            Id = p_inventory.Id;
            LineItemId = p_inventory.LineItemId;
            StoreId = p_inventory.StoreId;
            QuantityHeld = p_inventory.QuantityHeld;
            Price = p_inventory.Price;
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
    }
}

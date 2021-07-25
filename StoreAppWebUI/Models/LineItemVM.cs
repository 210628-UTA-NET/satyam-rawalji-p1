using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreAppModels;

namespace StoreAppWebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM(LineItem p_lineItem)
        {
            Id = p_lineItem.Id;
            Name = p_lineItem.Name;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

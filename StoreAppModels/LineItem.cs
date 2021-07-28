using System;
using System.ComponentModel.DataAnnotations;

namespace StoreAppModels
{
    public class LineItem
    {
        public LineItem() {}
        [Required]
        public int Id {get;set;}
        [Required]
        public string Name {get; set;}
    }
}
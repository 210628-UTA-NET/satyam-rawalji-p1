using System;
using System.ComponentModel.DataAnnotations;

namespace StoreAppModels
{
    public class StoreFront
    {
        public StoreFront() {}
        [Required]
        public int Id {get;set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Address {get; set;}
    }
}
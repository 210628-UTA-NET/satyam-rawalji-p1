using System;

namespace StoreAppModels
{
    public class LineItem
    {
        public LineItem() {}
        public int LId {get;set;}
        public int LSId {get;set;}
        public string Name {get; set;}
        public double Price {get; set;}
        public int Quantity {get; set;}
    }
}
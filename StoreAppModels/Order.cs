using System;

namespace StoreAppModels {
    public class Order {
        public Order() {}
        public int CId {get;set;}
        public int SId {get;set;}
        public string SName {get;set;}
        public double Total {get;set;}
        public DateTime Date {get;set;}
    }
}
using DatabaseProje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseProje.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public enumOrderState orderState { get; set; }
        public List<OrderLineModel> OrderLines { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string sehir { get; set; }
        public string semt { get; set; }
        public string mahalle { get; set; }

        public string postakodu { get; set; }
    }
    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
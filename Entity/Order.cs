using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseProje.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public enumOrderState orderState { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public string UserName { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string sehir { get; set; }
        public string semt { get; set; }
        public string mahalle { get; set; }

        public string postakodu { get; set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DatabaseProje.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün ismi")]
        public string Name { get; set; }
        [DisplayName("Ürün açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün fiyatı")]
        public double Price { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
    }
}
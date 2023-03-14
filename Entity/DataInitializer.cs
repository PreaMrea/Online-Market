using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseProje.Entity
{
    public class DataInitializer :DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var Kategoriler = new List<Category>()
            {
                new Category(){Name="Fotograf",Description="Fotograf urunleri"},
                new Category(){Name="Resimler",Description="Resim urunleri"}
            };
            foreach(var kategori in Kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            var urunler = new List<Product>
            {
                new Product(){Name="ozan",Description="ozan resmi",Price=9999,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="mete",Description="mete resmi",Price=9999,IsApproved=true,CategoryId=1 ,Image="1.jpg"},
                new Product(){Name="zafer",Description="zafer resmi",Price=9999,IsApproved=true,CategoryId=1,Image="1.jpg"},
                new Product(){Name="ahmet",Description="ahmet resmi",Price=9999,IsApproved=true,CategoryId=1,IsHome=true, Image="2.jpg"},
                new Product(){Name="ada",Description="ada resmi",Price=9999,IsApproved=true,CategoryId=1,Image="1.jpg"},
                new Product(){Name="sadi",Description="zafer resmi",Price=9999,IsApproved=true,CategoryId=2,Image="1.jpg"},
                new Product(){Name="evren",Description="ozan resmi",Price=9999,IsApproved=true,CategoryId=1,IsHome=true,Image="2.jpg"},
                new Product(){Name="sadık",Description="mete resmi",Price=9999,IsApproved=true,CategoryId=1,Image="2.jpg"},
                new Product(){Name="zsds",Description="zafer resmi",Price=9999,IsApproved=true,CategoryId=2,Image="2.jpg"},
                new Product(){Name="ozsds",Description="ozan resmi",Price=9999,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="metdsd",Description="mete resmi",Price=9999,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="zafasdad",Description="zafer resmi",Price=9999,IsApproved=true,CategoryId=2,IsHome=true,Image="2.jpg"}
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
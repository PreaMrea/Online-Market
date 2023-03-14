using DatabaseProje.Entity;
using DatabaseProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DatabaseProje.Controllers
{

    public class CartController : Controller
    {
        // GET: Cart
        private DataContext db= new DataContext();

        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if(product!=null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if(cart.CartLines.Count==0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    SaveOrder(cart, entity);
                    cart.Clear();
                    return View("Completed");
                }
                else
                {
                    return View(entity);
                }
            }
            return View(new ShippingDetails());
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.orderState = enumOrderState.Wating;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.sehir = entity.sehir;
            order.UserName = User.Identity.Name;
            order.semt = entity.semt;
            order.mahalle = entity.mahalle;
            order.postakodu = entity.postakodu;
            order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = pr.Quantity;
                orderLine.Price = pr.Quantity * pr.Product.Price;
                orderLine.ProductId = pr.Product.Id;
                order.OrderLines.Add(orderLine);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }

}

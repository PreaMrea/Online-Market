using DatabaseProje.Entity;
using DatabaseProje.Identity;
using DatabaseProje.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProje.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {

            var orders = db.Orders.Where(i => i.UserName == User.Identity.Name).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                orderState=i.orderState,
                Total=i.Total
            }) .OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber=i.OrderNumber,
                Total=i.Total,
                OrderDate=i.OrderDate,
                orderState=i.orderState,
                AdresBasligi=i.AdresBasligi,
                Adres=i.Adres,
                sehir=i.sehir,
                semt=i.semt,
                mahalle=i.mahalle,
                postakodu=i.postakodu,
                OrderLines=i.OrderLines.Select(a=>new OrderLineModel()
                {
                    ProductId=a.ProductId,
                    ProductName=a.Product.Name,
                    Image=a.Product.Image,
                    Quantity=a.Quantity,
                    Price=a.Price
                }).ToList()
            }).FirstOrDefault();
            return View(entity);
        }
        public ActionResult Register()
        {
            return View();
        }

        // GET: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.UserName;
                IdentityResult result=UserManager.Create(user, model.Password);
                if(result.Succeeded)
                {
                   if (RoleManager.RoleExists("user"))
                   {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                    
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma başarısız");
                }
            }
            return View(model);
        }


        public ActionResult Login()
        {
            return View();
        }
        // GET: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string RetrunUrl)
        {
            if (ModelState.IsValid)
            {
                var user=UserManager.Find(model.UserName, model.Password);
                if(user!=null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    if(!String.IsNullOrEmpty(RetrunUrl))
                    {
                        Redirect(RetrunUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulunamadı");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
using PizzaOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PizzaOrderApp.Controllers
{
    public class UsersController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            var count = db.UsersTab.Count(u => u.Username == user.Username && u.Password == user.Password);
            if(count == 1)
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                return RedirectToAction("Index", "Products");
            }
            else
            {
                ViewBag.LogInErr = "Username o password errati, riprova";
                return View();
            }
            
        }
    }
}
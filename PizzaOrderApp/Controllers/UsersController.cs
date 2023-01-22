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
                Users current = db.UsersTab.Where(u => u.Username == user.Username && u.Password == user.Password).First();
                FormsAuthentication.SetAuthCookie(current.Username, current.RememberMe);
                if (current.Role == "admin")
                {
                    return RedirectToAction("IndexAdmin", "Products");
                }
                else
                {
                    return Redirect(FormsAuthentication.DefaultUrl);
                }
            }
            else
            {
                ViewBag.LogInErr = "Che pizza, devi aver sbagliato credenziali :( Riprova.";
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");

        }

        public ActionResult SignIn() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Users user)
        {
            var count = db.UsersTab.Count(u => u.Username == user.Username);
            if(count == 0) {
                user.Role = "user";
                db.UsersTab.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Users");
            }
            else
            {
                ViewBag.UserExistMsg = "Sembra che questo username sia già in uso. Provane uno più Pizzastico!";
                return View();
            }    
            
        }

        [Authorize(Roles = "admin")]
        public ActionResult AdminSignIn()
        {
            List<SelectListItem> RolesList = new List<SelectListItem>();
            SelectListItem adminRole = new SelectListItem();
            adminRole.Text = "admin";
            adminRole.Value = "admin";
            RolesList.Add(adminRole);

            SelectListItem userRole = new SelectListItem();
            userRole.Text = "user";
            userRole.Value = "user";
            RolesList.Add(userRole);

            ViewBag.RolesList = RolesList;

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AdminSignIn(Users user)
        {
            var count = db.UsersTab.Count(u => u.Username == user.Username);
            if (count == 0)
            {
                
                db.UsersTab.Add(user);
                db.SaveChanges();
                return RedirectToAction("IndexAdmin", "Products");
            }
            else
            {
                ViewBag.UserExistMsg = "Sembra che questo username sia già in uso. Riprova";
                return View();
            }
        }

       
    }
}
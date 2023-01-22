using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzaOrderApp.Models;

namespace PizzaOrderApp.Controllers
{
    public class OrderTabsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: OrderTabs
        public ActionResult Index()
        {
            var orderTab = db.OrderTab.Include(o => o.UsersTab);
            return View(orderTab.ToList());
        }

        // GET: OrderTabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orderTab = db.OrderTab.Find(id);
            if (orderTab == null)
            {
                return HttpNotFound();
            }
            return View(orderTab);
        }

        // GET: OrderTabs/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.UsersTab, "UserID", "Username");
            return View();
        }

        // POST: OrderTabs/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,UserID,OrderDate,OrderTotal,OrderAdress,Delivered")] Order orderTab)
        {
            if (ModelState.IsValid)
            {
                db.OrderTab.Add(orderTab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.UsersTab, "UserID", "Username", orderTab.OrderID);
            return View(orderTab);
        }

        // GET: OrderTabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orderTab = db.OrderTab.Find(id);
            if (orderTab == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.UsersTab, "UserID", "Username", orderTab.OrderID);
            return View(orderTab);
        }

        // POST: OrderTabs/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,UserID,OrderDate,OrderTotal,OrderAdress,Delivered")] Order orderTab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderTab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.UsersTab, "UserID", "Username", orderTab.OrderID);
            return View(orderTab);
        }

        // GET: OrderTabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orderTab = db.OrderTab.Find(id);
            if (orderTab == null)
            {
                return HttpNotFound();
            }
            return View(orderTab);
        }

        // POST: OrderTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order orderTab = db.OrderTab.Find(id);
            db.OrderTab.Remove(orderTab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}

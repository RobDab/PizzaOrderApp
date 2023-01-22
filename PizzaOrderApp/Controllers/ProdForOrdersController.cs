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
    public class ProdForOrdersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ProdForOrders
        public ActionResult Index()
        {
            var prodForOrderTab = db.ProdForOrderTab.Include(p => p.OrderTab).Include(p => p.ProductsTab);
            return View(prodForOrderTab.ToList());
        }

        // GET: ProdForOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdForOrder prodForOrder = db.ProdForOrderTab.Find(id);
            if (prodForOrder == null)
            {
                return HttpNotFound();
            }
            return View(prodForOrder);
        }


        [Authorize]
        public ActionResult AddToOrder(ProdForOrder detail)
        {
            
            if(detail.Quantity != 0)
            {
                ProdForOrder.ProdList.Add(detail);
            }
            

            //ViewBag.OrderID = new SelectList(db.OrderTab, "OrderID", "OrderAdress");
            //ViewBag.ProductID = new SelectList(db.ProductsTab, "ProductID", "Name");
            return RedirectToAction("Index","Products");
        }



        // POST: ProdForOrders/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,OrderID,ProductID,Quantity")] ProdForOrder prodForOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ProdForOrderTab.Add(prodForOrder);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.OrderID = new SelectList(db.OrderTab, "OrderID", "OrderAdress", prodForOrder.OrderID);
        //    ViewBag.ProductID = new SelectList(db.ProductsTab, "ProductID", "Name", prodForOrder.ProductID);
        //    return View(prodForOrder);
        //}

        // GET: ProdForOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdForOrder prodForOrder = db.ProdForOrderTab.Find(id);
            if (prodForOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.OrderTab, "OrderID", "OrderAdress", prodForOrder.OrderID);
            ViewBag.ProductID = new SelectList(db.ProductsTab, "ProductID", "Name", prodForOrder.ProductID);
            return View(prodForOrder);
        }

        // POST: ProdForOrders/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderID,ProductID,Quantity")] ProdForOrder prodForOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodForOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.OrderTab, "OrderID", "OrderAdress", prodForOrder.OrderID);
            ViewBag.ProductID = new SelectList(db.ProductsTab, "ProductID", "Name", prodForOrder.ProductID);
            return View(prodForOrder);
        }

        // GET: ProdForOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdForOrder prodForOrder = db.ProdForOrderTab.Find(id);
            if (prodForOrder == null)
            {
                return HttpNotFound();
            }
            return View(prodForOrder);
        }

        // POST: ProdForOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdForOrder prodForOrder = db.ProdForOrderTab.Find(id);
            db.ProdForOrderTab.Remove(prodForOrder);
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

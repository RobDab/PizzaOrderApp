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
    public class ProductsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Products
        [Authorize(Roles = "admin")]
        public ActionResult IndexAdmin()
        {
            return View(db.ProductsTab.ToList());
        }
        public ActionResult Index()
        {
            return View(db.ProductsTab.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Home");
            }
            try
            {
                Products product = db.ProductsTab.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch
            {
                ViewBag.ErrMsg = "Qualcosa è andato storto, torna alla Home";
                
            }
            
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Price,DeliveryTime,Ingredients")] Products product, HttpPostedFileBase uploadedImg)
        {
            if (ModelState.IsValid)
            {
                if(uploadedImg == null)
                {
                    ViewBag.UploadErr = "Carica un'immagine per la nuova Pizza!";
                    return View(product);
                }
                else
                {
                    product.URLImg = uploadedImg.FileName;
                    string path = Server.MapPath("~/Content/Assets/" + uploadedImg.FileName);
                    uploadedImg.SaveAs(path);
                }

                db.ProductsTab.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products productsTab = db.ProductsTab.Find(id);
            if (productsTab == null)
            {
                return HttpNotFound();
            }
            return View(productsTab);
        }

        // POST: Products/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,URLImg,Price,DeliveryTime,Ingredients")] Products productsTab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsTab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productsTab);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products productsTab = db.ProductsTab.Find(id);
            if (productsTab == null)
            {
                return HttpNotFound();
            }
            return View(productsTab);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products productsTab = db.ProductsTab.Find(id);
            db.ProductsTab.Remove(productsTab);
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

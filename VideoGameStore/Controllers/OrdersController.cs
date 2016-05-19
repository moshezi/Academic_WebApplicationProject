using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    [Authorize(Roles="Admin")]
    public class OrdersController : Controller
    {
        private VideoGamesStoreContext db = new VideoGamesStoreContext();

        // GET: Orders
        public ActionResult Index(string name, string phone, string city)
        {
            var orders = db.Orders.Include(s => s.Products).ToList();
            if (name != null)
            {
                orders = orders.Where(s => s.customerName.ToLower().Contains(name.ToLower())).ToList();
            }
            if (phone != null)
            {
                orders = orders.Where(s => s.customerPhone.Contains(phone)).ToList();
            }

            if (city != null)
            {
                orders = orders.Where(s => s.city.ToLower().Contains(city.ToLower())).ToList();
            }
            ViewBag.backgroundID = "orders1";
            return View(orders);
        }

        public ActionResult Statistics()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult getOrderStats()
        {
            var data = from s in db.Products.Include("Orders")
                       select new
                       {
                           Product = s.productName,
                           Count = s.Orders.Count
                       };
            return this.Json(data.Where(d => d.Count != 0).ToList(), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult getBranches()
        {
            var data = from o in db.Orders
                       select new
                       {
                           Branch = o.OrderID,
                           City = o.city,
                           Address = o.adress
                       };
            return this.Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        [AllowAnonymous]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                //ViewBag.ProductID = new SelectList(db.Products, "ProductID", "productName");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ProductID = new SelectList(db.Products, "ProductID", "productName", id);
                Products product = db.Products.FirstOrDefault(p => p.ProductID == id);
                ViewBag.ProductPrice = product.price;
            }

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProductID,customerName,customerPhone,city,adress,orderPrice")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "productName", orders.ProductID);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "productName", orders.ProductID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,customerName,customerPhone,city,adress,orderPrice")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "productName", orders.ProductID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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

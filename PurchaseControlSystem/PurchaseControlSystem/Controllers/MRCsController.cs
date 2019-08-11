using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseControlSystem.Models;

namespace PurchaseControlSystem.Controllers
{
    public class MRCsController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: MRCs
        public ActionResult Index()
        {
            var mRCs = db.MRCs.Include(m => m.Supplier).Include(m => m.Product);
            return View(mRCs.ToList());
        }

        // GET: MRCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MRC mRC = db.MRCs.Find(id);
            if (mRC == null)
            {
                return HttpNotFound();
            }
            return View(mRC);
        }

        // GET: MRCs/Create
        public ActionResult Create()
        {
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short");
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: MRCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MRC_Id,ProductId_FK,AccountId_FK,Description,Unit,Pack_Size,UnitRate,OtherCharges")] MRC mRC)
        {
            if (ModelState.IsValid)
            {
                db.MRCs.Add(mRC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", mRC.AccountId_FK);
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName", mRC.ProductId_FK);
            return View(mRC);
        }

        // GET: MRCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MRC mRC = db.MRCs.Find(id);
            if (mRC == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", mRC.AccountId_FK);
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName", mRC.ProductId_FK);
            return View(mRC);
        }

        // POST: MRCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MRC_Id,ProductId_FK,AccountId_FK,Description,Unit,Pack_Size,UnitRate,OtherCharges")] MRC mRC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mRC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", mRC.AccountId_FK);
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName", mRC.ProductId_FK);
            return View(mRC);
        }

        // GET: MRCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MRC mRC = db.MRCs.Find(id);
            if (mRC == null)
            {
                return HttpNotFound();
            }
            return View(mRC);
        }

        // POST: MRCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MRC mRC = db.MRCs.Find(id);
            db.MRCs.Remove(mRC);
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

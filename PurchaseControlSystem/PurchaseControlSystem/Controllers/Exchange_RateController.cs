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
    public class Exchange_RateController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Exchange_Rate
        public ActionResult Index()
        {
            return View(db.Exchange_Rate.ToList());
        }

        // GET: Exchange_Rate/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exchange_Rate exchange_Rate = db.Exchange_Rate.Find(id);
            if (exchange_Rate == null)
            {
                return HttpNotFound();
            }
            return View(exchange_Rate);
        }

        // GET: Exchange_Rate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exchange_Rate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Description,Abbreviation,Rate,BankCTRL,DiffCTRL")] Exchange_Rate exchange_Rate)
        {
            if (ModelState.IsValid)
            {
                db.Exchange_Rate.Add(exchange_Rate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exchange_Rate);
        }

        // GET: Exchange_Rate/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exchange_Rate exchange_Rate = db.Exchange_Rate.Find(id);
            if (exchange_Rate == null)
            {
                return HttpNotFound();
            }
            return View(exchange_Rate);
        }

        // POST: Exchange_Rate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Description,Abbreviation,Rate,BankCTRL,DiffCTRL")] Exchange_Rate exchange_Rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchange_Rate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exchange_Rate);
        }

        // GET: Exchange_Rate/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exchange_Rate exchange_Rate = db.Exchange_Rate.Find(id);
            if (exchange_Rate == null)
            {
                return HttpNotFound();
            }
            return View(exchange_Rate);
        }

        // POST: Exchange_Rate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exchange_Rate exchange_Rate = db.Exchange_Rate.Find(id);
            db.Exchange_Rate.Remove(exchange_Rate);
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

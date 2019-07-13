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
    public class VAT_CodeController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: VAT_Code
        public ActionResult Index()
        {
            return View(db.VAT_Code.ToList());
        }

        // GET: VAT_Code/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAT_Code vAT_Code = db.VAT_Code.Find(id);
            if (vAT_Code == null)
            {
                return HttpNotFound();
            }
            return View(vAT_Code);
        }

        // GET: VAT_Code/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VAT_Code/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VAT_Code1,VATCodeDesc")] VAT_Code vAT_Code)
        {
            if (ModelState.IsValid)
            {
                db.VAT_Code.Add(vAT_Code);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vAT_Code);
        }

        // GET: VAT_Code/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAT_Code vAT_Code = db.VAT_Code.Find(id);
            if (vAT_Code == null)
            {
                return HttpNotFound();
            }
            return View(vAT_Code);
        }

        // POST: VAT_Code/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VAT_Code1,VATCodeDesc")] VAT_Code vAT_Code)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vAT_Code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vAT_Code);
        }

        // GET: VAT_Code/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAT_Code vAT_Code = db.VAT_Code.Find(id);
            if (vAT_Code == null)
            {
                return HttpNotFound();
            }
            return View(vAT_Code);
        }

        // POST: VAT_Code/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VAT_Code vAT_Code = db.VAT_Code.Find(id);
            db.VAT_Code.Remove(vAT_Code);
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

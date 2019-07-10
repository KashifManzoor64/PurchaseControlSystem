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
    public class Terms_ConditionController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Terms_Condition
        public ActionResult Index()
        {
            return View(db.Terms_Condition.ToList());
        }

        // GET: Terms_Condition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms_Condition terms_Condition = db.Terms_Condition.Find(id);
            if (terms_Condition == null)
            {
                return HttpNotFound();
            }
            return View(terms_Condition);
        }

        // GET: Terms_Condition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terms_Condition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Terms_code,Description")] Terms_Condition terms_Condition)
        {
            if (ModelState.IsValid)
            {
                db.Terms_Condition.Add(terms_Condition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terms_Condition);
        }

        // GET: Terms_Condition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms_Condition terms_Condition = db.Terms_Condition.Find(id);
            if (terms_Condition == null)
            {
                return HttpNotFound();
            }
            return View(terms_Condition);
        }

        // POST: Terms_Condition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Terms_code,Description")] Terms_Condition terms_Condition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terms_Condition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terms_Condition);
        }

        // GET: Terms_Condition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms_Condition terms_Condition = db.Terms_Condition.Find(id);
            if (terms_Condition == null)
            {
                return HttpNotFound();
            }
            return View(terms_Condition);
        }

        // POST: Terms_Condition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terms_Condition terms_Condition = db.Terms_Condition.Find(id);
            db.Terms_Condition.Remove(terms_Condition);
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

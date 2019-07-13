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
    public class VAT_GroupController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: VAT_Group
        public ActionResult Index()
        {
            return View(db.VAT_Group.ToList());
        }

        // GET: VAT_Group/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAT_Group vAT_Group = db.VAT_Group.Find(id);
            if (vAT_Group == null)
            {
                return HttpNotFound();
            }
            return View(vAT_Group);
        }

        // GET: VAT_Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VAT_Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VAT_Group1,VATGroupDesc,Currency,SLADJUST,PLADJUST,SDBASIS,EUGROUP")] VAT_Group vAT_Group)
        {
            if (ModelState.IsValid)
            {
                db.VAT_Group.Add(vAT_Group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vAT_Group);
        }

        // GET: VAT_Group/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAT_Group vAT_Group = db.VAT_Group.Find(id);
            if (vAT_Group == null)
            {
                return HttpNotFound();
            }
            return View(vAT_Group);
        }

        // POST: VAT_Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VAT_Group1,VATGroupDesc,Currency,SLADJUST,PLADJUST,SDBASIS,EUGROUP")] VAT_Group vAT_Group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vAT_Group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vAT_Group);
        }

        // GET: VAT_Group/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAT_Group vAT_Group = db.VAT_Group.Find(id);
            if (vAT_Group == null)
            {
                return HttpNotFound();
            }
            return View(vAT_Group);
        }

        // POST: VAT_Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VAT_Group vAT_Group = db.VAT_Group.Find(id);
            db.VAT_Group.Remove(vAT_Group);
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

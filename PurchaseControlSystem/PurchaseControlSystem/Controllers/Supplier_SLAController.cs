using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseControlSystem.Models;
using System.IO;

namespace PurchaseControlSystem.Controllers
{
    public class Supplier_SLAController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Supplier_SLA
        public ActionResult Index()
        {
            var supplier_SLA = db.Supplier_SLA.Include(s => s.Supplier);
            return View(supplier_SLA.ToList());
        }

        // GET: Supplier_SLA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_SLA supplier_SLA = db.Supplier_SLA.Find(id);
            if (supplier_SLA == null)
            {
                return HttpNotFound();
            }
            return View(supplier_SLA);
        }

        // GET: Supplier_SLA/Create
        public ActionResult Create()
        {
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Supplier_SLA supplier_SLA)
        {
            if (ModelState.IsValid)
            {
                //Extract Image File Name.
                string fileName = Path.GetFileName(file.FileName);

                //Set the Image File Path.
                string filePath = "~/Content/Supplier_SLA/" + fileName;
                string filename = fileName;
                //Save the Image File in Folder.
                file.SaveAs(Server.MapPath(filePath));

                //Insert the Image File details in Table.
                
                db.Supplier_SLA.Add(new Supplier_SLA
                {
                    AccountId_FK = supplier_SLA.AccountId_FK,
                    SLA = filePath,
                    FileName = filename
                });
                db.SaveChanges();

                //Redirect to Index Action.
                return RedirectToAction("Index");

                //db.Supplier_SLA.Add(supplier_SLA);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", supplier_SLA.AccountId_FK);
            return View(supplier_SLA);
        }

        // GET: Supplier_SLA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_SLA supplier_SLA = db.Supplier_SLA.Find(id);
            if (supplier_SLA == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", supplier_SLA.AccountId_FK);
            return View(supplier_SLA);
        }

        // POST: Supplier_SLA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supplier_SLAId,AccountId_FK,SLA")] Supplier_SLA supplier_SLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier_SLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", supplier_SLA.AccountId_FK);
            return View(supplier_SLA);
        }

        // GET: Supplier_SLA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_SLA supplier_SLA = db.Supplier_SLA.Find(id);
            if (supplier_SLA == null)
            {
                return HttpNotFound();
            }
            return View(supplier_SLA);
        }

        // POST: Supplier_SLA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_SLA supplier_SLA = db.Supplier_SLA.Find(id);
            db.Supplier_SLA.Remove(supplier_SLA);
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

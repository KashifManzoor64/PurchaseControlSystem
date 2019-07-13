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
    public class SuppliersController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = db.Suppliers.Include(s => s.Division).Include(s => s.Exchange_Rate).Include(s => s.VAT_Code).Include(s => s.VAT_Group);
            return View(suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name");
            ViewBag.Currency_FK = new SelectList(db.Exchange_Rate, "Code", "Description");
            ViewBag.VAT_Code_FK = new SelectList(db.VAT_Code, "VAT_Code1", "VATCodeDesc");
            ViewBag.VAT_Group_FK = new SelectList(db.VAT_Group, "VAT_Group1", "VATGroupDesc");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,Short,Name,Address1,Address2,Address3,Address4,Address5,Phone,Currency_FK,DivisionId_FK,CreditTerms,VAT_Group_FK,VAT_Code_FK,Acccount_Type,NLCONTROL,Supplier_Category,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name", supplier.DivisionId_FK);
            ViewBag.Currency_FK = new SelectList(db.Exchange_Rate, "Code", "Description", supplier.Currency_FK);
            ViewBag.VAT_Code_FK = new SelectList(db.VAT_Code, "VAT_Code1", "VATCodeDesc", supplier.VAT_Code_FK);
            ViewBag.VAT_Group_FK = new SelectList(db.VAT_Group, "VAT_Group1", "VATGroupDesc", supplier.VAT_Group_FK);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name", supplier.DivisionId_FK);
            ViewBag.Currency_FK = new SelectList(db.Exchange_Rate, "Code", "Description", supplier.Currency_FK);
            ViewBag.VAT_Code_FK = new SelectList(db.VAT_Code, "VAT_Code1", "VATCodeDesc", supplier.VAT_Code_FK);
            ViewBag.VAT_Group_FK = new SelectList(db.VAT_Group, "VAT_Group1", "VATGroupDesc", supplier.VAT_Group_FK);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,Short,Name,Address1,Address2,Address3,Address4,Address5,Phone,Currency_FK,DivisionId_FK,CreditTerms,VAT_Group_FK,VAT_Code_FK,Acccount_Type,NLCONTROL,Supplier_Category,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name", supplier.DivisionId_FK);
            ViewBag.Currency_FK = new SelectList(db.Exchange_Rate, "Code", "Description", supplier.Currency_FK);
            ViewBag.VAT_Code_FK = new SelectList(db.VAT_Code, "VAT_Code1", "VATCodeDesc", supplier.VAT_Code_FK);
            ViewBag.VAT_Group_FK = new SelectList(db.VAT_Group, "VAT_Group1", "VATGroupDesc", supplier.VAT_Group_FK);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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

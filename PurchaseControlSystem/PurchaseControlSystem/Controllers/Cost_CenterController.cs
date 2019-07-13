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
    public class Cost_CenterController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Cost_Center
        public ActionResult Index()
        {
            var cost_Center = db.Cost_Center.Include(c => c.Department).Include(c => c.Division);
            return View(cost_Center.ToList());
        }

        // GET: Cost_Center/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost_Center cost_Center = db.Cost_Center.Find(id);
            if (cost_Center == null)
            {
                return HttpNotFound();
            }
            return View(cost_Center);
        }

        // GET: Cost_Center/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name");
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name");
            return View();
        }

        // POST: Cost_Center/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CostCenterId,Description,DivisionId_FK,DepartmentId_FK")] Cost_Center cost_Center)
        {
            if (ModelState.IsValid)
            {
                db.Cost_Center.Add(cost_Center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", cost_Center.DepartmentId_FK);
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name", cost_Center.DivisionId_FK);
            return View(cost_Center);
        }

        // GET: Cost_Center/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost_Center cost_Center = db.Cost_Center.Find(id);
            if (cost_Center == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", cost_Center.DepartmentId_FK);
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name", cost_Center.DivisionId_FK);
            return View(cost_Center);
        }

        // POST: Cost_Center/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CostCenterId,Description,DivisionId_FK,DepartmentId_FK")] Cost_Center cost_Center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cost_Center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", cost_Center.DepartmentId_FK);
            ViewBag.DivisionId_FK = new SelectList(db.Divisions, "DivisionId", "Division_Name", cost_Center.DivisionId_FK);
            return View(cost_Center);
        }

        // GET: Cost_Center/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost_Center cost_Center = db.Cost_Center.Find(id);
            if (cost_Center == null)
            {
                return HttpNotFound();
            }
            return View(cost_Center);
        }

        // POST: Cost_Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cost_Center cost_Center = db.Cost_Center.Find(id);
            db.Cost_Center.Remove(cost_Center);
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

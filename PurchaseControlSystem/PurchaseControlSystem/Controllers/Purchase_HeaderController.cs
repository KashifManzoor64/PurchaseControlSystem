using PurchaseControlSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PurchaseControlSystem.Controllers
{
    public class Purchase_HeaderController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Purchase_Header
        public ActionResult Index()
        {
            var purchase_Header = db.Purchase_Header.Include(p => p.Cost_Center).Include(p => p.Department).Include(p => p.Supplier);
            return View(purchase_Header.ToList());
        }

        //// GET: Purchase_Header/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Purchase_Header purchase_Header = db.Purchase_Header.Find(id);
        //    if (purchase_Header == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(purchase_Header);
        //}

        // GET: Purchase_Header/Create
        public ActionResult Create()
        {
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId");
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name");
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId");
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name");
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "OrderNo,CostCenterId_FK,AccountId_FK,DepartmentId_FK,Status,SupplierName,SupplierAddress,CreatedBy,CreatedDate,AmendedBy,AmendedDate,FinanceApproved,OperationApproved,InitalsBy,Comments")]*/ Purchase_Header purchase_Header)
        {
            if (ModelState.IsValid)
            {

                var PH = db.Set<Purchase_Header>();
                PH.Add(new Purchase_Header
                {
                    CostCenterId_FK = purchase_Header.CostCenterId_FK,
                    AccountId_FK = purchase_Header.AccountId_FK,
                    DepartmentId_FK = purchase_Header.DepartmentId_FK,
                    Status = purchase_Header.Status,
                    SupplierName = purchase_Header.SupplierName,
                    SupplierAddress = purchase_Header.SupplierAddress,
                    Comments = purchase_Header.Comments,
                    CreatedBy = "Hamza",
                    CreatedDate = DateTime.Now
                });

                db.SaveChanges();

                //db.Purchase_Header.Add(purchase_Header);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchase_Header.CostCenterId_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", purchase_Header.DepartmentId_FK);
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", purchase_Header.AccountId_FK);
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name", purchase_Header.SupplierName);
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1", purchase_Header.SupplierAddress);
            return View(purchase_Header);
        }

        // GET: Purchase_Header/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Header purchase_Header = db.Purchase_Header.Find(id);
            if (purchase_Header == null)
            {
                return HttpNotFound();
            }
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchase_Header.CostCenterId_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", purchase_Header.DepartmentId_FK);
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", purchase_Header.AccountId_FK);
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name", purchase_Header.SupplierName);
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1", purchase_Header.SupplierAddress);
            return View(purchase_Header);
        }

        // POST: Purchase_Header/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderNo,CostCenterId_FK,AccountId_FK,DepartmentId_FK,Status,SupplierName,SupplierAddress,AmendedBy,AmendedDate,Comments")] Purchase_Header purchase_Header)
        {
            //Purchase_Header purchaseHeaderDB = new Purchase_Header();
            if (ModelState.IsValid)
            {
                //var PH = db.Entry<Purchase_Header>();
                //PH.Add(new Purchase_Header {
                //    CostCenterId_FK = purchase_Header.CostCenterId_FK,
                //    AccountId_FK = purchase_Header.AccountId_FK,
                //    DepartmentId_FK = purchase_Header.DepartmentId_FK,
                //    Status = purchase_Header.Status,
                //    SupplierName = purchase_Header.SupplierName,
                //    SupplierAddress = purchase_Header.SupplierAddress,
                //    Comments = purchase_Header.Comments,
                //    AmendedBy = "Admin",
                //    AmendedDate = DateTime.Now

                //});
                //new Purchase_Header
                //{
                //    CostCenterId_FK = purchase_Header.CostCenterId_FK,
                //    AccountId_FK = purchase_Header.AccountId_FK,
                //    DepartmentId_FK = purchase_Header.DepartmentId_FK,
                //    Status = purchase_Header.Status,
                //    SupplierName = purchase_Header.SupplierName,
                //    SupplierAddress = purchase_Header.SupplierAddress,
                //    Comments = purchase_Header.Comments,
                //    AmendedBy = "Admin",
                //    AmendedDate = DateTime.Now
                //}
                //var PH = db.Purchase_Header;
                //Purchase_Header  purchaseHeaderDB = new Purchase_Header();
                //purchaseHeaderDB.CostCenterId_FK = purchase_Header.CostCenterId_FK;
                //purchaseHeaderDB.AccountId_FK = purchase_Header.AccountId_FK;
                //purchaseHeaderDB.DepartmentId_FK = purchase_Header.DepartmentId_FK;
                //purchaseHeaderDB.Status = purchase_Header.Status;
                //purchaseHeaderDB.SupplierName = purchase_Header.SupplierName;
                //purchaseHeaderDB.SupplierAddress = purchase_Header.SupplierAddress;
                //purchaseHeaderDB.Comments = purchase_Header.Comments;
                //purchaseHeaderDB.AmendedBy = "Admin";
                //purchaseHeaderDB.AmendedDate = DateTime.Now;


                //db.Purchase_Header.Add(purchaseHeaderDB);
                db.Database.ExecuteSqlCommand("Update Purchase_Header set CostCenterId_FK = '" + purchase_Header.CostCenterId_FK + "', AccountId_FK = '" + purchase_Header.AccountId_FK + "', DepartmentId_FK = '" + purchase_Header.DepartmentId_FK + "', Status = '" + purchase_Header.Status + "', SupplierName = '" + purchase_Header.SupplierName + "', SupplierAddress = '" + purchase_Header.SupplierAddress + "', Comments = '" + purchase_Header.Comments + "', AmendedBy = '" + "Admin" + "', AmendedDate = '" + DateTime.Now + "' where OrderNo = '"+purchase_Header.OrderNo+"'");
                //Entry(purchaseHeaderDB).State = EntityState.Modified;
                //Entry(purchaseHeaderDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchase_Header.CostCenterId_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", purchase_Header.DepartmentId_FK);
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", purchase_Header.AccountId_FK);
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name", purchase_Header.SupplierName);
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1", purchase_Header.SupplierAddress);
            return View(purchase_Header);
        }

        //// GET: Purchase_Header/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Purchase_Header purchase_Header = db.Purchase_Header.Find(id);
        //    if (purchase_Header == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(purchase_Header);
        //}

        //// POST: Purchase_Header/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Purchase_Header purchase_Header = db.Purchase_Header.Find(id);
        //    db.Purchase_Header.Remove(purchase_Header);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

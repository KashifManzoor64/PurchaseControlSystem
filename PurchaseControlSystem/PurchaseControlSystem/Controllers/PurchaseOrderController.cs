using PurchaseControlSystem.Models;
using PurchaseControlSystem.ViewModel;
using System;
using System.Web.Mvc;

namespace PurchaseControlSystem.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();
        // GET: PurchaseOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: PurchaseOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseOrder/Create
        public ActionResult CreatePurchaseOrder()
        {
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId");
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name");
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId");
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name");
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1");
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductId");
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductName", "ProductName");
            ViewBag.Suffix_FK =new SelectList(db.Suffixes, "Suffix_Id", "Suffix1");
            return View();
        }

        // POST: PurchaseOrder/Create
        [HttpPost]
        public ActionResult CreatePurchaseOrder(PurchaseOrder_VM purchaseOrder_VM)
        {
            try
            {
                // TODO: Add insert logic here

                Purchase_Header purchase_Header = new Purchase_Header();
                purchase_Header.CostCenterId_FK = purchaseOrder_VM.CostCenterId_FK;
                purchase_Header.AccountId_FK = purchaseOrder_VM.AccountId_FK;
                purchase_Header.DepartmentId_FK = purchaseOrder_VM.DepartmentId_FK;
                purchase_Header.Status = purchaseOrder_VM.Status;
                purchase_Header.SupplierName = purchaseOrder_VM.SupplierName;
                purchase_Header.SupplierAddress = purchaseOrder_VM.SupplierAddress;
                purchase_Header.Comments = purchaseOrder_VM.Comments;
                purchase_Header.CreatedBy = "Ashok";
                purchase_Header.CreatedDate = DateTime.Now;

                //adding object to model
                db.Purchase_Header.Add(purchase_Header);
                //saving changes
                db.SaveChanges();

                //getting back the orderNumber PK from purchase header
                int OrderNo = purchase_Header.OrderNo;

                //inserting data into transaction table

                Purchase_Transaction purchase_Transaction = new Purchase_Transaction();
                purchase_Transaction.ProductId_FK = purchaseOrder_VM.ProductId_FK;
                purchase_Transaction.ProductName = purchaseOrder_VM.ProductName;
                purchase_Transaction.Suffix_FK = purchaseOrder_VM.Suffix_FK;
                purchase_Transaction.Quantity = purchaseOrder_VM.Quantity;
                purchase_Transaction.PackSize = purchaseOrder_VM.PackSize;
                purchase_Transaction.UnitPrice = purchaseOrder_VM.UnitPrice;
                purchase_Transaction.GrossValue = purchaseOrder_VM.GrossValue;
                purchase_Transaction.LpoStatus = purchaseOrder_VM.LpoStatus;
                purchase_Transaction.TermsCode = purchaseOrder_VM.TermsCode;

                db.Purchase_Transaction.Add(purchase_Transaction);
                db.SaveChanges();

                return RedirectToAction("Index", "CreatePurchaseOrder");

                //ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchase_Header.CostCenterId_FK);
                //ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", purchase_Header.DepartmentId_FK);
                //ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", purchase_Header.AccountId_FK);
                //ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name", purchase_Header.SupplierName);
                //ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1", purchase_Header.SupplierAddress);
                //return View(purchase_Header);

            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

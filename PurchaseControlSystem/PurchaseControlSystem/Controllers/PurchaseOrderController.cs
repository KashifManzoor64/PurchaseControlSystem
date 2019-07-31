using PurchaseControlSystem.Models;
using PurchaseControlSystem.ViewModel;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PurchaseControlSystem.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public int OrderNo;
        
        public PurchaseOrderController()
        {

        }
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
        public ActionResult Create()
        {

            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId");
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name");
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId");
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name");
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1");
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.ProductName = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.Name = new SelectList(db.Users, "UserId", "Name");
            //ViewBag.Suffix_FK =new SelectList(db.Suffixes, "Suffix_Id", "Suffix");
            return View();
        }
        public ActionResult Make()
        {

            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId");
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name");
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId");
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name");
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1");
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.ProductName = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.Name = new SelectList(db.Users, "UserId", "Name");
            //ViewBag.Suffix_FK =new SelectList(db.Suffixes, "Suffix_Id", "Suffix");
            return View();
        }

        // POST: PurchaseOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrder_VM purchaseOrder_VM)
        {
            if (ModelState.IsValid)
            {
                

                //Purchase_Header purchase_Header = new Purchase_Header();
                //purchase_Header.CostCenterId_FK = Convert.ToInt32(purchaseOrder_VM.CostCenterId_FK);
                //purchase_Header.AccountId_FK = Convert.ToString(purchaseOrder_VM.AccountId_FK);
                //purchase_Header.DepartmentId_FK = Convert.ToInt32(purchaseOrder_VM.DepartmentId_FK);
                //purchase_Header.Status = purchaseOrder_VM.Status;
                //purchase_Header.SupplierName = purchaseOrder_VM.SupplierName;
                //purchase_Header.SupplierAddress = purchaseOrder_VM.SupplierAddress;
                //purchase_Header.Comments = purchaseOrder_VM.Comments;
                //purchase_Header.CreatedBy = "Ashok";
                //purchase_Header.CreatedDate = DateTime.Now;

                var orderNumber = db.Database.SqlQuery<int>(@"insert into Purchase_Header (CostCenterId_FK, AccountId_FK, DepartmentId_FK, Status, SupplierName, SupplierAddress, CreatedBy, CreatedDate, Comments) values ('" + purchaseOrder_VM.CostCenterId_FK + "', '" + purchaseOrder_VM.AccountId_FK + "', '" + purchaseOrder_VM.DepartmentId_FK + "', '" + purchaseOrder_VM.Status + "', '" + purchaseOrder_VM.SupplierName + "', '" + purchaseOrder_VM.SupplierAddress + "' , '" + "Ashok" + "' , '" + DateTime.Now + "' , '" + purchaseOrder_VM.Comments + "'); SELECT CAST(SCOPE_IDENTITY() AS INT)").Single();
                //adding object to model
                //db.Purchase_Header.Add(purchase_Header);
                //saving changes
                db.SaveChanges();
                //Session["CostCentreId"] = Convert.ToInt32(purchaseOrder_VM.CostCenterId_FK);
                //Session["AccountId"] = Convert.ToString(purchaseOrder_VM.AccountId_FK);
                //getting back the orderNumber PK from purchase header
                //OrderNo = purchase_Header.OrderNo;

                //inserting data into transaction table

                Purchase_Transaction purchase_Transaction = new Purchase_Transaction();

                purchase_Transaction.OrderNo_FK = orderNumber;
                purchase_Transaction.ProductId_FK = Convert.ToInt32(purchaseOrder_VM.ProductId_FK);
                //PurchaseOrder != null && !string.nullOrEmpty(PurchaseOrder.ProductName)
                purchase_Transaction.ProductName = purchaseOrder_VM != null && !string.IsNullOrEmpty(purchaseOrder_VM.ProductName) ? purchaseOrder_VM.ProductName.ToString() : "";
                purchase_Transaction.CostCenterId_FK = purchaseOrder_VM.CostCenterId_FK;
                purchase_Transaction.AccountId_FK = purchaseOrder_VM.AccountId_FK;
                purchase_Transaction.Suffix = purchaseOrder_VM.Suffix;
                purchase_Transaction.Quantity = purchaseOrder_VM.Quantity;
                purchase_Transaction.PackSize = purchaseOrder_VM.PackSize;
                purchase_Transaction.UnitPrice = purchaseOrder_VM.UnitPrice;
                purchase_Transaction.GrossValue = purchaseOrder_VM.GrossValue;
                purchase_Transaction.LpoStatus = purchaseOrder_VM.LpoStatus;
                purchase_Transaction.TermsCode = purchaseOrder_VM.TermsCode;
                purchase_Transaction.ApproverId = purchase_Transaction.ApproverId;
                //purchase_Transaction. = purchaseOrder_VM.TermsCode;

                db.Purchase_Transaction.Add(purchase_Transaction);
                db.SaveChanges();



                return RedirectToAction("Index", "PurchaseOrder");



            }
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchaseOrder_VM.CostCenterId_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", purchaseOrder_VM.DepartmentId_FK);
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", purchaseOrder_VM.AccountId_FK);
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name", purchaseOrder_VM.SupplierName);
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1", purchaseOrder_VM.SupplierAddress);
            //added later
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductId", purchaseOrder_VM.ProductId_FK);
            ViewBag.ProductName = new SelectList(db.Products, "ProductName", "ProductName", purchaseOrder_VM.ProductName);
            ViewBag.Name = new SelectList(db.Users, "UserId", "Name", purchaseOrder_VM.ApproverName);
            return View(purchaseOrder_VM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Make(PurchaseOrder_VM purchaseOrder_VM)
        {
            if (ModelState.IsValid)
            {
                

                //Purchase_Header purchase_Header = new Purchase_Header();
                //purchase_Header.CostCenterId_FK = Convert.ToInt32(purchaseOrder_VM.CostCenterId_FK);
                //purchase_Header.AccountId_FK = Convert.ToString(purchaseOrder_VM.AccountId_FK);
                //purchase_Header.DepartmentId_FK = Convert.ToInt32(purchaseOrder_VM.DepartmentId_FK);
                //purchase_Header.Status = purchaseOrder_VM.Status;
                //purchase_Header.SupplierName = purchaseOrder_VM.SupplierName;
                //purchase_Header.SupplierAddress = purchaseOrder_VM.SupplierAddress;
                //purchase_Header.Comments = purchaseOrder_VM.Comments;
                //purchase_Header.CreatedBy = "Ashok";
                //purchase_Header.CreatedDate = DateTime.Now;

                var orderNumber = db.Database.SqlQuery<int>(@"insert into Purchase_Header (CostCenterId_FK, AccountId_FK, DepartmentId_FK, Status, SupplierName, SupplierAddress, CreatedBy, CreatedDate, Comments) values ('" + purchaseOrder_VM.CostCenterId_FK + "', '" + purchaseOrder_VM.AccountId_FK + "', '" + purchaseOrder_VM.DepartmentId_FK + "', '" + purchaseOrder_VM.Status + "', '" + purchaseOrder_VM.SupplierName + "', '" + purchaseOrder_VM.SupplierAddress + "' , '" + "Ashok" + "' , '" + DateTime.Now + "' , '" + purchaseOrder_VM.Comments + "'); SELECT CAST(SCOPE_IDENTITY() AS INT)").Single();
                //adding object to model
                //db.Purchase_Header.Add(purchase_Header);
                //saving changes
                db.SaveChanges();
                //Session["CostCentreId"] = Convert.ToInt32(purchaseOrder_VM.CostCenterId_FK);
                //Session["AccountId"] = Convert.ToString(purchaseOrder_VM.AccountId_FK);
                //getting back the orderNumber PK from purchase header
                //OrderNo = purchase_Header.OrderNo;

                //inserting data into transaction table

                Purchase_Transaction purchase_Transaction = new Purchase_Transaction();

                purchase_Transaction.OrderNo_FK = orderNumber;
                purchase_Transaction.ProductId_FK = Convert.ToInt32(purchaseOrder_VM.ProductId_FK);
                //PurchaseOrder != null && !string.nullOrEmpty(PurchaseOrder.ProductName)
                purchase_Transaction.ProductName = purchaseOrder_VM != null && !string.IsNullOrEmpty(purchaseOrder_VM.ProductName) ? purchaseOrder_VM.ProductName.ToString() : "";
                purchase_Transaction.CostCenterId_FK = purchaseOrder_VM.CostCenterId_FK;
                purchase_Transaction.AccountId_FK = purchaseOrder_VM.AccountId_FK;
                purchase_Transaction.Suffix = purchaseOrder_VM.Suffix;
                purchase_Transaction.Quantity = purchaseOrder_VM.Quantity;
                purchase_Transaction.PackSize = purchaseOrder_VM.PackSize;
                purchase_Transaction.UnitPrice = purchaseOrder_VM.UnitPrice;
                purchase_Transaction.GrossValue = purchaseOrder_VM.GrossValue;
                purchase_Transaction.LpoStatus = purchaseOrder_VM.LpoStatus;
                purchase_Transaction.TermsCode = purchaseOrder_VM.TermsCode;
                //purchase_Transaction. = purchaseOrder_VM.TermsCode;

                db.Purchase_Transaction.Add(purchase_Transaction);
                db.SaveChanges();



                return RedirectToAction("Index", "PurchaseOrder");



            }
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchaseOrder_VM.CostCenterId_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", purchaseOrder_VM.DepartmentId_FK);
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "AccountId", purchaseOrder_VM.AccountId_FK);
            ViewBag.SupplierName = new SelectList(db.Suppliers, "Name", "Name", purchaseOrder_VM.SupplierName);
            ViewBag.SupplierAddress = new SelectList(db.Suppliers, "Address1", "Address1", purchaseOrder_VM.SupplierAddress);
            //added later
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductId", purchaseOrder_VM.ProductId_FK);
            ViewBag.ProductName = new SelectList(db.Products, "ProductName", "ProductName", purchaseOrder_VM.ProductName);
            ViewBag.Name = new SelectList(db.Users, "UserId", "Name", purchaseOrder_VM.ApproverName);
            return View(purchaseOrder_VM);

        }

        [HttpPost]
        public ActionResult getSupplierByName(string supplier)
        {
            //var dealercontacts = from contact in 
            //                     join dealer in Dealer on contact.DealerId equals dealer.ID
            //                     select contact;
            try
            {
                var sup = db.Suppliers.Where(x => x.Name == supplier).Select(x => new { AccountId = x.AccountId, Address1 = x.Address1 }).FirstOrDefault();
                // db.Configuration.LazyLoadingEnabled = true;
                return Json(sup);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        // GET: Purchase_Header/Details/5
        [HttpPost]
        public ActionResult getProductById(int id)
        {
            try
            {
                var product = db.Products.Where(x=>x.ProductId==id).Select(x=>new { Id=x.ProductId,Name=x.ProductName, UnitPrice = x.UnitPrice, Suffix = x.Suffix, PackSize = x.PackSize}).FirstOrDefault();
               // db.Configuration.LazyLoadingEnabled = true;
                return Json(product);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            //var jss = new JavaScriptSerializer();
            //var pro = jss.Deserialize(id);

            //var jss = new JavaScriptSerializer();
            //var dataObject = jss.Deserialize(id);
            // .. do something with data object 
            //return Json("OK");

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

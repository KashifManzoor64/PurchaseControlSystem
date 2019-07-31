using PurchaseControlSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PurchaseControlSystem.Controllers
{
    public class Purchase_TransactionController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Purchase_Transaction
        public ActionResult Index()
        {
            var purchase_Transaction = db.Purchase_Transaction.Include(p => p.Product).Include(p => p.Purchase_Header);
            db.Configuration.LazyLoadingEnabled = true;
            return View(purchase_Transaction.ToList());
        }

        // GET: Purchase_Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Transaction purchase_Transaction = db.Purchase_Transaction.Find(id);
            if (purchase_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Transaction);
        }

        // GET: Purchase_Transaction/Create
        public ActionResult Create()
        {
            ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "Description");
            ViewBag.ItemCategoryId_FK = new SelectList(db.Item_Category, "ItemCategoryId", "Description");
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductId");
            ViewBag.OrderNo_FK = new SelectList(db.Purchase_Header, "OrderNo", "AccountId_FK");
            ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short");
            //ViewBag.Suffix_FK = new SelectList(db.Suffixes, "Suffix_Id", "Suffix1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Purchase_TransactionId,OrderNo_FK,CostCenterId_FK,ProductId_FK,UnitPrice,Quantity,PackSize,GrossValue,ReceiveDate,ReceiveBy,VarifiedBy,VarifiedDate,ItemCategoryId_FK,TermsCode,AccountId_FK,TermsPrinted,Suffix_FK,LpoStatus,FinanceApproved,OperationApproved,CurrentValue,BaseValue,CurrentVAT,BaseVAT")] Purchase_Transaction purchase_Transaction)
        {
            if (ModelState.IsValid)
            {
                //var ph = db.Purchase_Header
                //            .SqlQuery();
                //db.Database.SqlQuery()
                //var ph = new Purchase_Header();
                //Purchase_Header purchase_Header = new Purchase_Header();
                //var orderNo = purchase_Header.OrderNo;
                //var accountid = purchase_Header.AccountId_FK;
                //var costCentre = purchase_Header.CostCenterId_FK;
                //var Number = Convert.ToInt32(TempData["OrderNo"]);
                //SELECT* FROM table_name ORDER BY column_name ASC | DESC
                //var ordernumber = db.Purchase_Header.SqlQuery("select OrderNo from Purchase_Header where OrderNo = OrderNo ORDER BY OrderNo DESC").FirstOrDefault();
                var ON = (int)Session["OrderNo"];
                var costCentre = (int)Session["CostCentreId"];
                var supplier = (string)Session["AccountId"];
                var PH = db.Set<Purchase_Transaction>();
                PH.Add(new Purchase_Transaction
                {
                    OrderNo_FK = Convert.ToInt32(ON),
                    //AccountId_FK = Convert.ToString(Session["AccountId_FK"]),
                    //CostCenterId_FK = Convert.ToInt32(Session["CostCenterId_FK"]),
                    ProductId_FK = Convert.ToInt32(purchase_Transaction.ProductId_FK),
                    ProductName = Convert.ToString(purchase_Transaction.ProductName),
                    CostCenterId_FK = Convert.ToInt32(costCentre),
                    AccountId_FK = Convert.ToString(supplier),
                    //Suffix_FK = purchase_Transaction.Suffix_FK,
                    Quantity = purchase_Transaction.Quantity,
                    PackSize = purchase_Transaction.PackSize,
                    UnitPrice = purchase_Transaction.UnitPrice,
                    GrossValue = purchase_Transaction.GrossValue,
                    LpoStatus = purchase_Transaction.LpoStatus,
                    TermsCode = purchase_Transaction.TermsCode
                    //    using(Purchase_Header purchase_Header = new Purchase_Header())
                    //{
                    //    }

                });

                
                db.SaveChanges();


                //db.Purchase_Transaction.Add(PH);

                return RedirectToAction("Create");
            }

            //ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", purchase_Transaction.CostCenterId_FK);
            //ViewBag.ItemCategoryId_FK = new SelectList(db.Item_Category, "ItemCategoryId", "ItemCategoryId", purchase_Transaction.ItemCategoryId_FK);
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductId", purchase_Transaction.ProductId_FK);
            ViewBag.OrderNo_FK = new SelectList(db.Purchase_Header, "OrderNo", "OrderNo", purchase_Transaction.OrderNo_FK);
            //ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", purchase_Transaction.AccountId_FK);
            //ViewBag.Suffix_FK = new SelectList(db.Suffixes, "Suffix_Id", "Suffix_Id", purchase_Transaction.Suffix_FK);
            return View(purchase_Transaction);
        }

        // GET: Purchase_Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Transaction purchase_Transaction = db.Purchase_Transaction.Find(id);
            if (purchase_Transaction == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "Description", purchase_Transaction.CostCenterId_FK);
            //ViewBag.ItemCategoryId_FK = new SelectList(db.Item_Category, "ItemCategoryId", "Description", purchase_Transaction.ItemCategoryId_FK);
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName", purchase_Transaction.ProductId_FK);
            ViewBag.OrderNo_FK = new SelectList(db.Purchase_Header, "OrderNo", "AccountId_FK", purchase_Transaction.OrderNo_FK);
            //ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", purchase_Transaction.AccountId_FK);
            ViewBag.Suffix_FK = new SelectList(db.Suffixes, "Suffix_Id", "Suffix1", purchase_Transaction.Suffix);
            return View(purchase_Transaction);
        }

        // POST: Purchase_Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Purchase_TransactionId,OrderNo_FK,CostCenterId_FK,ProductId_FK,UnitPrice,Quantity,PackSize,GrossValue,ReceiveDate,ReceiveBy,VarifiedBy,VarifiedDate,ItemCategoryId_FK,TermsCode,AccountId_FK,TermsPrinted,Suffix_FK,LpoStatus,FinanceApproved,OperationApproved,CurrentValue,BaseValue,CurrentVAT,BaseVAT")] Purchase_Transaction purchase_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_Transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CostCenterId_FK = new SelectList(db.Cost_Center, "CostCenterId", "Description", purchase_Transaction.CostCenterId_FK);
            //ViewBag.ItemCategoryId_FK = new SelectList(db.Item_Category, "ItemCategoryId", "Description", purchase_Transaction.ItemCategoryId_FK);
            ViewBag.ProductId_FK = new SelectList(db.Products, "ProductId", "ProductName", purchase_Transaction.ProductId_FK);
            //ViewBag.OrderNo_FK = new SelectList(db.Purchase_Header, "OrderNo", "AccountId_FK", purchase_Transaction.OrderNo_FK);
            //ViewBag.AccountId_FK = new SelectList(db.Suppliers, "AccountId", "Short", purchase_Transaction.AccountId_FK);
            //ViewBag.Suffix_FK = new SelectList(db.Suffixes, "Suffix_Id", "Suffix1", purchase_Transaction.Suffix_FK);
            return View(purchase_Transaction);
        }

        // GET: Purchase_Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Transaction purchase_Transaction = db.Purchase_Transaction.Find(id);
            if (purchase_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Transaction);
        }

        // POST: Purchase_Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase_Transaction purchase_Transaction = db.Purchase_Transaction.Find(id);
            db.Purchase_Transaction.Remove(purchase_Transaction);
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

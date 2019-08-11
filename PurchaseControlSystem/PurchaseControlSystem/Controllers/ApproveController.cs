using PurchaseControlSystem.Models;
using PurchaseControlSystem.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PurchaseControlSystem.Controllers
{
    public class ApproveController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();
        // GET: Approve
        public ActionResult Index()
        {
            var approveList = db.Purchase_Transaction.Include(p => p.Purchase_Header).Include(p => p.Supplier).Include(p => p.Cost_Center).Where(x => x.ApproverId == 1);

            //var PO = (from pt in db.Purchase_Transaction
            //          where pt.ApproverId == 1
            //          join ph in db.Purchase_Header on pt.OrderNo_FK equals ph.OrderNo
            //          //join PD in db.Departments on ph.DepartmentId_FK equals pt.DepartmentId
            //          select new
            //          {
            //              ph.OrderNo,
            //              ph.CostCenterId_FK,
            //              ph.AccountId_FK,
            //              ph.Department.Department_name,
            //              ph.Status,
            //              ph.SupplierName,
            //              ph.SupplierAddress,
            //              ph.Comments,
            //              ph.CreatedBy,
            //              ph.CreatedDate,
            //              pt.ProductId_FK,
            //              pt.ProductName,
            //              pt.UnitPrice,
            //              pt.Quantity,
            //              pt.PackSize,
            //              pt.GrossValue,
            //              pt.TermsCode,
            //              pt.Suffix,
            //              pt.LpoStatus
            //          }).FirstOrDefault();

            //PurchaseOrder_VM purchaseOrder_VM = new PurchaseOrder_VM();

            //purchaseOrder_VM.OrderNo = PO.OrderNo;
            //purchaseOrder_VM.AccountId_FK = PO.AccountId_FK;
            //purchaseOrder_VM.SupplierName = PO.SupplierName;
            //purchaseOrder_VM.CreatedDate = PO.CreatedDate;
            //purchaseOrder_VM.DepartmentName = PO.Department_name;
            //purchaseOrder_VM.CostCenterId_FK = PO.CostCenterId_FK;
            //purchaseOrder_VM.CreatedBy = PO.CreatedBy;
            //purchaseOrder_VM.GrossValue = PO.GrossValue;
            //purchaseOrder_VM.Status = PO.LpoStatus;

            //purchaseOrder_VM.SupplierAddress = PO.SupplierAddress;
            //purchaseOrder_VM.Comments = PO.Comments;

            //purchaseOrder_VM.ProductId_FK = PO.ProductId_FK;
            //purchaseOrder_VM.ProductName = PO.ProductName;
            //purchaseOrder_VM.UnitPrice = PO.UnitPrice;
            //purchaseOrder_VM.Quantity = PO.Quantity;
            //purchaseOrder_VM.PackSize = PO.PackSize;

            //purchaseOrder_VM.TermsCode = PO.TermsCode;
            //purchaseOrder_VM.Suffix = PO.Suffix;
            //var obj = approveList.ToList(), purchaseOrder_VM;
            return View(approveList.ToList());
            //return View();
        }


        public ActionResult Details(int? id)
        {

            //var sup = db.Suppliers.Where(x => x.Name == supplier).Select(x => new { AccountId = x.AccountId, Address1 = x.Address1 }).FirstOrDefault();


            //ViewBag.Details = db.Purchase_Transaction.Include(p => p.Purchase_Header).Include(p => p.Supplier).Include(p => p.Cost_Center).Where(x => x.OrderNo_FK == id );

            PurchaseOrder_VM purchaseOrder_VM = new PurchaseOrder_VM();


            //var PO = (from ph in db.Purchase_Header
            //          join pt in db.Purchase_Transaction on ph.OrderNo equals pt.OrderNo_FK
            //          //where pt.OrderNo_FK == id
            //          select new
            //          {
            //              ph.OrderNo,
            //              ph.CostCenterId_FK,
            //              ph.AccountId_FK,
            //              ph.Department.Department_name,
            //              ph.CreatedDate,
            //              ph.Status,
            //              ph.SupplierName,
            //              ph.SupplierAddress,
            //              ph.Comments,
            //              pt.ProductId_FK,
            //              pt.ProductName,
            //              pt.UnitPrice,
            //              pt.Quantity,
            //              pt.PackSize,
            //              pt.GrossValue,
            //              pt.TermsCode,
            //              pt.Suffix,
            //              pt.LpoStatus
            //          }).FirstOrDefault();

            var PO = (from ph in db.Purchase_Header
                      where ph.OrderNo == id
                      select new
                      {
                          ph.OrderNo,
                          ph.CostCenterId_FK,
                          ph.AccountId_FK,
                          ph.Department.Department_name,
                          ph.CreatedDate,
                          ph.Status,
                          ph.SupplierName,
                          ph.SupplierAddress,
                          ph.Comments,

                      }).FirstOrDefault();


            //Purchase_Header purchase_Header = db.Purchase_Header.Where(y => y.OrderNo == id).FirstOrDefault();    /*.Select(y => new { OrderNum = y.OrderNo })*/
            //                                                                                                      //Find(id);

            purchaseOrder_VM.OrderNo = PO.OrderNo;
            purchaseOrder_VM.CostCenterId_FK = PO.CostCenterId_FK;
            purchaseOrder_VM.AccountId_FK = PO.AccountId_FK;
            purchaseOrder_VM.DepartmentName = PO.Department_name;
            purchaseOrder_VM.CreatedDate = PO.CreatedDate;
            purchaseOrder_VM.Status = PO.Status;
            purchaseOrder_VM.SupplierName = PO.SupplierName;
            purchaseOrder_VM.SupplierAddress = PO.SupplierAddress;
            purchaseOrder_VM.Comments = PO.Comments;

            //purchaseOrder_VM.ProductId_FK = PO.ProductId_FK;
            //purchaseOrder_VM.ProductName = PO.ProductName;
            //purchaseOrder_VM.UnitPrice = PO.UnitPrice;
            //purchaseOrder_VM.Quantity = PO.Quantity;
            //purchaseOrder_VM.PackSize = PO.PackSize;
            //purchaseOrder_VM.GrossValue = PO.GrossValue;
            //purchaseOrder_VM.TermsCode = PO.TermsCode;
            //purchaseOrder_VM.Suffix = PO.Suffix;
            //purchaseOrder_VM.LpoStatus = PO.LpoStatus;

            //int ON = purchase_Header.OrderNo;

            //var sup = db.Suppliers.Where(x => x.Name == supplier).Select(x => new { AccountId = x.AccountId, Address1 = x.Address1 }).FirstOrDefault();
            //var result = from p in db.Purchase_Transaction
            //             where p.OrderNo_FK == ON
            //             select new
            //             {
            //                 p.ProductId_FK
            //             };

            //c IN db.Customers
            // WHERE c.Address.State == "WA"
            // SELECT NEW
            // {
            //                 c.Name,
            //    c.CustomerNumber,
            //    HighValuePurchases = c.Purchases.Where(p => p.Price > 1000)
            // }
            //from p in db.Purchase_Transaction
            //where ()
            //select p;
            //////Purchase_Transaction purchase_Transaction = db.Purchase_Transaction.Where(y => y.OrderNo_FK == id).FirstOrDefault();
            //var purchase_Transaction = db.Purchase_Transaction.Where(y => y.OrderNo_FK == id).Select(y => new { ProductId_FK = y.ProductId_FK, ProductName = y.ProductName,  UnitPrice = y.UnitPrice, Quantity = y.Quantity, PackSize =y.PackSize, GrossValue = y.GrossValue, TermsCode= y.TermsCode, Suffix = y.Suffix, LpoStatus = y.LpoStatus }).FirstOrDefault();
            //var p_T = db.Purchase_Transaction.Where(y => y.OrderNo_FK == ON).Select() .FirstOrDefault();
            //db.Purchase_Transaction.Find(ON);

            //purchaseOrder_VM.ProductId_FK = purchase_Transaction.ProductId_FK;
            //purchaseOrder_VM.ProductName = purchase_Transaction.ProductName;
            //purchaseOrder_VM.UnitPrice = purchase_Transaction.UnitPrice;
            //purchaseOrder_VM.Quantity = purchase_Transaction.Quantity;
            //purchaseOrder_VM.PackSize = purchase_Transaction.PackSize;
            //purchaseOrder_VM.GrossValue = purchase_Transaction.GrossValue;
            //purchaseOrder_VM.TermsCode = purchase_Transaction.TermsCode;
            //purchaseOrder_VM.Suffix = purchase_Transaction.Suffix;
            //purchaseOrder_VM.LpoStatus = purchase_Transaction.LpoStatus;

            //purchaseOrder_VM.ProductId_FK = purchase_Transaction.ProductId_FK;



            if (purchaseOrder_VM == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder_VM);
        }


        [HttpPost]
        public ActionResult getOrderlinesByOrderNo(int orderNo)
        {

            //var lines = db.Purchase_Transaction.Where(x => x.OrderNo_FK == orderNo).Select(x => new { ProductId_FK = x.ProductId_FK/*, ProductName = x.ProductName, Suffix = x.Suffix, Quantity = x.Quantity, PackSize = x.PackSize, UnitPrice = x.UnitPrice, GrossValue = x.GrossValue, LpoStatus = x.LpoStatus */}).FirstOrDefault();
            //// db.Configuration.LazyLoadingEnabled = true;
            //return Json(lines);

            try
            {
                //var lines = db.Purchase_Transaction.SqlQuery("Select * from Purchase_Transaction where OrderNo_FK=@id", new SqlParameter("@id", orderNo));
                var lines = db.Purchase_Transaction.Where(x => x.OrderNo_FK == orderNo).Select(x => new
                {
                    ProductId_FK = x.ProductId_FK,
                    ProductName = x.ProductName,
                    Suffix = x.Suffix,
                    Quantity = x.Quantity,
                    PackSize = x.PackSize,
                    UnitPrice = x.UnitPrice,
                    GrossValue = x.GrossValue,
                    LpoStatus = x.LpoStatus
                }).ToList();

                //var lines = db.Purchase_Transaction.Where(x => x.OrderNo_FK == orderNo).Select(x => new { ProductId_FK = x.ProductId_FK }).FirstOrDefault();
                // db.Configuration.LazyLoadingEnabled = true;
                return Json(lines.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }


            //return Json(orderNo);
        }


        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}

        //    //if (product == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //var jss = new JavaScriptSerializer();
        //    //var pro = jss.Deserialize(id);

        //    //var jss = new JavaScriptSerializer();
        //    //var dataObject = jss.Deserialize(id);
        //    // .. do something with data object 
        //    //return Json("OK");

        //}

        public ActionResult Approve(int? id)
        {

            var query = "UPDATE Purchase_Transaction SET OperationApproved = 'Approved', LpoStatus = 'P' WHERE OrderNo_FK = '" + id + "'";

            db.Database.ExecuteSqlCommand(query);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
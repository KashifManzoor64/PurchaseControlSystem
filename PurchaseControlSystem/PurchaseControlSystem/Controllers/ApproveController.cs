using PurchaseControlSystem.Models;
using PurchaseControlSystem.ViewModel;
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
            var approveList = db.Purchase_Header.Include(p => p.Purchase_Transaction).Include(p => p.Department).Include(p => p.Supplier).Include(p => p.Cost_Center);

            return View(approveList.ToList());
            //return View();
        }



        public ActionResult Details(int? id)
        {

            //var sup = db.Suppliers.Where(x => x.Name == supplier).Select(x => new { AccountId = x.AccountId, Address1 = x.Address1 }).FirstOrDefault();

            PurchaseOrder_VM purchaseOrder_VM = new PurchaseOrder_VM();


            var PO = (from ph in db.Purchase_Header
                     join pt in db.Purchase_Transaction on ph.OrderNo equals pt.OrderNo_FK
                     select new
                     {
                         ph.OrderNo,
                         ph.CostCenterId_FK,
                         ph.AccountId_FK,
                         ph.DepartmentId_FK,
                         ph.Status,
                         ph.SupplierName,
                         ph.SupplierAddress,
                         ph.Comments,
                         pt.ProductId_FK,
                         pt.ProductName,
                         pt.UnitPrice,
                         pt.Quantity,
                         pt.PackSize,
                         pt.GrossValue,
                         pt.TermsCode,
                         pt.Suffix,
                         pt.LpoStatus
                     }).FirstOrDefault();


            //Purchase_Header purchase_Header = db.Purchase_Header.Where(y => y.OrderNo == id).FirstOrDefault();    /*.Select(y => new { OrderNum = y.OrderNo })*/
            //                                                                                                      //Find(id);

            purchaseOrder_VM.OrderNo = PO.OrderNo;
            purchaseOrder_VM.CostCenterId_FK = PO.CostCenterId_FK;
            purchaseOrder_VM.AccountId_FK = PO.AccountId_FK;
            purchaseOrder_VM.DepartmentId_FK = PO.DepartmentId_FK;
            purchaseOrder_VM.Status = PO.Status;
            purchaseOrder_VM.SupplierName = PO.SupplierName;
            purchaseOrder_VM.SupplierAddress = PO.SupplierAddress;
            purchaseOrder_VM.Comments = PO.Comments;

            purchaseOrder_VM.ProductId_FK = PO.ProductId_FK;
            purchaseOrder_VM.ProductName = PO.ProductName;
            purchaseOrder_VM.UnitPrice = PO.UnitPrice;
            purchaseOrder_VM.Quantity = PO.Quantity;
            purchaseOrder_VM.PackSize = PO.PackSize;
            purchaseOrder_VM.GrossValue = PO.GrossValue;
            purchaseOrder_VM.TermsCode = PO.TermsCode;
            purchaseOrder_VM.Suffix = PO.Suffix;
            purchaseOrder_VM.LpoStatus = PO.LpoStatus;

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

        public ActionResult Approve(int? id)
        {

            var query = "UPDATE Purchase_Transaction SET OperationApproved = 'Approved', LpoStatus = 'P' WHERE OrderNo_FK = '"+id+"'";

            db.Database.ExecuteSqlCommand(query);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
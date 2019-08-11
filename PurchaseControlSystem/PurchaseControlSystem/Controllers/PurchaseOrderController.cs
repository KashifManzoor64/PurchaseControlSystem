using PurchaseControlSystem.Models;
using PurchaseControlSystem.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PurchaseControlSystem.Controllers
{
    public class PurchaseOrderController : Controller
    {
        #region DB_Connection
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        #endregion

        #region AjaxCalls

        [HttpPost]
        public ActionResult getSupplierByName(string supplier)
        {
            //var dealercontacts = from contact in 
            //                     join dealer in Dealer on contact.DealerId equals dealer.ID
            //                     select contact;
            try
            {
                var sup = db.Suppliers.Where(x => x.Name == supplier).Select(x => new
                {
                    AccountId = x.AccountId,
                    Address1 = x.Address1
                }
            ).FirstOrDefault();
                // db.Configuration.LazyLoadingEnabled = true;
                return Json(sup);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult getDepartmentByCostCentre(int costCentre)
        {
            //var dealercontacts = from contact in 
            //                     join dealer in Dealer on contact.DealerId equals dealer.ID
            //                     select contact;
            try
            {
                var sup = db.Cost_Center.Where(x => x.CostCenterId == costCentre).Select(x => new
                {
                    DepartmentId_FK = x.DepartmentId_FK
                }
            ).FirstOrDefault();
                // db.Configuration.LazyLoadingEnabled = true;
                return Json(sup);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        public ActionResult getTemsConditions(int productId)
        {
            try
            {
                var condsIds = db.Products.Where(x => x.ProductId == productId).Select(x => new {
                    TermsCode = x.TermsCode
                }).Single();
                var desc = db.Terms_Condition;
                   
                //from Description in db.Terms_Condition select Description;


                var result = new { conditionids = condsIds , terms = desc.ToList() };
                return Json(result, JsonRequestBehavior.AllowGet);

                //var condsIds = db.Database.SqlQuery("select TermsCode from Products where ProductId = (" + productId + ")").ToList();

                //Terms_Condition_VM[] condsIds = db.Database.SqlQuery<Array>(@"select * from Terms_Condition where TermsCode in (" + condsIds + ")").ToList();
                //return Json(condsIds.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult getProductById(int id)
        {
            try
            {
                var product = db.Products.Where(x => x.ProductId == id).Select(x => new
                {
                    Id = x.ProductId,
                    Name = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Suffix = x.Suffix,
                    PackSize = x.PackSize
                }
                ).FirstOrDefault();
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

        public ActionResult Download()
        {
            string path = HttpContext.Server.MapPath("~/Content/Supplier_SLA/ApplicationPrint.pdf");
            //@"F:\2019\ZwawiTraders\Code\PurchaseControlSystem\PurchaseControlSystem\PurchaseControlSystem\Content\Supplier_SLA\ApplicationPrint.pdf");
            return Json(new { path = path });
        }

        public FileStreamResult GetPDF()
        {
            //string fileName = "gr_phase3_ac_2019.pdf";
            //StreamReader reader = new StreamReader("F:\\2019\\ZwawiTraders\\Code\\PurchaseControlSystem\\PurchaseControlSystem\\PurchaseControlSystem\\Content\\Supplier_SLA\\" + fileName);

            //return new FileStreamResult(reader.BaseStream, "application/pdf");


            //Response.AppendHeader("content-disposition", "inline; filename=gr_phase3_ac_2019.pdf"); 
            string filename = "ApplicationPrint.pdf";

            FileStream fs = new FileStream(@"F:\2019\ZwawiTraders\Code\PurchaseControlSystem\PurchaseControlSystem\PurchaseControlSystem\Content\Supplier_SLA\ApplicationPrint.pdf", FileMode.Open, FileAccess.Read);
            Response.AddHeader("Content-Disposition", "inline; filename='" + filename + "'");
            return File(fs, "application/pdf");
        }
        #endregion

        #region FormMethodsGet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

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



        public ActionResult Edit(int id)
        {
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        #endregion

        #region PostFormMethods

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
                purchase_Transaction.LpoStatus = "N";
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


        //[HttpPost]
        //public ActionResult getSlaBySupplierName(string supplierName)
        //{
        //    //var dealercontacts = from contact in 
        //    //                     join dealer in Dealer on contact.DealerId equals dealer.ID
        //    //                     select contact;
        //    try
        //    {
        //        var sup = db.Supplier_SLA.Where(x => x.AccountId_FK == supplierName).Select(x => new
        //        {
        //            SupplierSLA = x.SLA
        //        }
        //    ).FirstOrDefault();
        //        // db.Configuration.LazyLoadingEnabled = true;
        //        return Json(sup);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}




        //[HttpPost]
        //public FileStreamResult GetPDF(int id)
        //{
        //    FileStream fs = new FileStream("~/Content/assets/Supplier_SLA/gr_phase3_ac_2019.pdf", FileMode.Open, FileAccess.Read);
        //    return File(fs, "application/pdf");
        //}


        [HttpPost]
        public ActionResult createPOAjax(
                string CostCenterId_FK,
                string AccountId_FK,
                string DepartmentId_FK,
                string Status,
                string SupplierName,
                string SupplierAddress,
                int Approver,
                string Comments,
                string transData
            )
        {
            //var dealercontacts = from contact in 
            //                     join dealer in Dealer on contact.DealerId equals dealer.ID
            //                     select contact;
            try
            {
                var orderNumber = db.Database.SqlQuery<int>(@"insert into Purchase_Header 
                    (
                        CostCenterId_FK, 
                        AccountId_FK, 
                        DepartmentId_FK, 
                        Status, 
                        SupplierName, 
                        SupplierAddress, 
                        CreatedBy, 
                        CreatedDate, 
                        Comments
                    ) values (
                        '" + CostCenterId_FK + "', " +
                        "'" + AccountId_FK + "', " +
                        "'" + DepartmentId_FK + "', " +
                        "'" + Status + "', " +
                        "'" + SupplierName + "', " +
                        "'" + SupplierAddress + "' , " +
                        "'" + "Ashok" + "' , " +
                        "'" + DateTime.Now + "' , " +
                        "'" + Comments + "'" +
                        "); SELECT CAST(SCOPE_IDENTITY() AS INT)").Single();

                db.SaveChanges();


                PurchaseOrder_VM[] tData = new JavaScriptSerializer().Deserialize<PurchaseOrder_VM[]>(transData);

                for (var i = 0; i < tData.Length; i++)
                {
                    Purchase_Transaction purchase_Transaction = new Purchase_Transaction();

                    purchase_Transaction.OrderNo_FK = orderNumber;
                    purchase_Transaction.ProductId_FK = Convert.ToInt32(tData[i].ProductId_FK);
                    //purchase_Transaction.ProductName = purchaseOrder_VM != null && !string.IsNullOrEmpty(purchaseOrder_VM.ProductName) ? purchaseOrder_VM.ProductName.ToString() : "";
                    purchase_Transaction.CostCenterId_FK = Convert.ToInt32(CostCenterId_FK);
                    purchase_Transaction.AccountId_FK = AccountId_FK;
                    //purchase_Transaction.Suffix = purchaseOrder_VM.Suffix;
                    purchase_Transaction.Quantity = tData[i].Quantity;
                    //purchase_Transaction.PackSize = purchaseOrder_VM.PackSize;
                    purchase_Transaction.UnitPrice = tData[i].UnitPrice;
                    purchase_Transaction.GrossValue = tData[i].GrossValue;
                    purchase_Transaction.LpoStatus = "N";
                    purchase_Transaction.TermsCode = tData[i].TermsCode;
                    purchase_Transaction.ApproverId = Approver;
                    purchase_Transaction.ExchangeRate = tData[i].ExchangeRate;
                    //purchase_Transaction. = purchaseOrder_VM.TermsCode;

                    db.Purchase_Transaction.Add(purchase_Transaction);
                    db.SaveChanges();
                }
                return Json(tData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

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


        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        } 
        #endregion
    }
}

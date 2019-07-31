using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseControlSystem.ViewModel
{
    public class PurchaseOrder_VM
    {
        public PurchaseOrder_VM()
        {

        }
        public int OrderNo { get; set; }

        public int CostCenterId_FK { get; set; }

        public string AccountId_FK { get; set; }

        public int DepartmentId_FK { get; set; }

        public string Status { get; set; }

        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }

        public string Comments { get; set; }

        //PUrchaseTransaction from here        

        public int ProductId_FK { get; set; }

        public string ProductName { get; set; }

        public Nullable<decimal> UnitPrice { get; set; }

        public Nullable<decimal> Quantity { get; set; }

        public Nullable<int> PackSize { get; set; }

        public Nullable<decimal> GrossValue { get; set; }
        
        public int TermsCode { get; set; }        

        public int Suffix { get; set; }

        public string LpoStatus { get; set; }


        public IEnumerable<SelectListItem> ApproverName { get; set; }


        //public SelectList UserId { get; set; }

    }
}
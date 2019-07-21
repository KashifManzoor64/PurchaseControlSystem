using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseControlSystem.ViewModel
{
    public class PurchaseOrder_VM
    {

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

        public decimal Quantity { get; set; }

        public int PackSize { get; set; }

        public Nullable<decimal> GrossValue { get; set; }
        
        public int TermsCode { get; set; }        

        public int Suffix_FK { get; set; }

        public string LpoStatus { get; set; }

    }
}
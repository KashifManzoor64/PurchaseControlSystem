//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PurchaseControlSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Expense_Category
    {
        public int Expense_Category_Id { get; set; }
        public string Description { get; set; }
        public int ItemCategoryId_FK { get; set; }
        public int ExpenseId_FK { get; set; }
    
        public virtual Expense Expense { get; set; }
        public virtual Item_Category Item_Category { get; set; }
    }
}

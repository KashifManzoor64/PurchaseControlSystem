
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
    
public partial class Expense
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Expense()
    {

        this.Accounts = new HashSet<Account>();

        this.Expense_Category = new HashSet<Expense_Category>();

    }


    public int ExpenseId { get; set; }

    public string Short { get; set; }

    public string Description { get; set; }

    public string AccountName { get; set; }

    public string Actype { get; set; }

    public string Exgroup { get; set; }

    public string BANK { get; set; }

    public string Currency { get; set; }

    public string Suffmask { get; set; }

    public int DivId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Account> Accounts { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Expense_Category> Expense_Category { get; set; }

}

}


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
    
public partial class Item_Category
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Item_Category()
    {

        this.Expense_Category = new HashSet<Expense_Category>();

        this.Products = new HashSet<Product>();

        this.Purchase_Transaction = new HashSet<Purchase_Transaction>();

    }


    public int ItemCategoryId { get; set; }

    public string Description { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Expense_Category> Expense_Category { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Product> Products { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Purchase_Transaction> Purchase_Transaction { get; set; }

}

}

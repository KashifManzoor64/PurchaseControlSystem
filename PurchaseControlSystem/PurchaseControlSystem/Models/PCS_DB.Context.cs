﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class Purchase_Control_SystemEntities : DbContext
{
    public Purchase_Control_SystemEntities()
        : base("name=Purchase_Control_SystemEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cost_Center> Cost_Center { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Exchange_Rate> Exchange_Rate { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Expense_Category> Expense_Category { get; set; }

    public virtual DbSet<Item_Category> Item_Category { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MRC> MRCs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Suffix> Suffixes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supplier_Addition> Supplier_Addition { get; set; }

    public virtual DbSet<Supplier_Quotes> Supplier_Quotes { get; set; }

    public virtual DbSet<Supplier_SLA> Supplier_SLA { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Terms_Condition> Terms_Condition { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<User_Authorise> User_Authorise { get; set; }

    public virtual DbSet<User_Setup> User_Setup { get; set; }

    public virtual DbSet<VAT_Code> VAT_Code { get; set; }

    public virtual DbSet<VAT_Group> VAT_Group { get; set; }

    public virtual DbSet<Verified_Transaction> Verified_Transaction { get; set; }

    public virtual DbSet<Purchase_Header> Purchase_Header { get; set; }

    public virtual DbSet<Purchase_Transaction> Purchase_Transaction { get; set; }

}

}


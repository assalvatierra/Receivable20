﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArDBContainer : DbContext
    {
        public ArDBContainer()
            : base("name=ArDBContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArTransaction> ArTransactions { get; set; }
        public virtual DbSet<ArTransPost> ArTransPosts { get; set; }
        public virtual DbSet<ArPayment> ArPayments { get; set; }
        public virtual DbSet<ArTransStatus> ArTransStatus { get; set; }
        public virtual DbSet<ArAccount> ArAccounts { get; set; }
        public virtual DbSet<ArAccStatus> ArAccStatus { get; set; }
        public virtual DbSet<ArAction> ArActions { get; set; }
        public virtual DbSet<ArActionItem> ArActionItems { get; set; }
        public virtual DbSet<ArTransPayment> ArTransPayments { get; set; }
        public virtual DbSet<ArPaymentType> ArPaymentTypes { get; set; }
    }
}

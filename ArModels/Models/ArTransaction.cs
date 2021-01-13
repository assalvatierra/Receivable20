//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArModels.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArTransaction()
        {
            this.ArTransPosts = new HashSet<ArTransPost>();
            this.ArActions = new HashSet<ArAction>();
            this.ArTransPayments = new HashSet<ArTransPayment>();
        }
    
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public System.DateTime DtInvoice { get; set; }
        public string Description { get; set; }
        public System.DateTime DtEncoded { get; set; }
        public System.DateTime DtDue { get; set; }
        public decimal Amount { get; set; }
        public int Interval { get; set; }
        public bool IsRepeating { get; set; }
        public string Remarks { get; set; }
        public int ArTransStatusId { get; set; }
        public int ArAccountId { get; set; }
        public int ArCategoryId { get; set; }
        public System.DateTime DtService { get; set; }
        public Nullable<System.DateTime> DtServiceTo { get; set; }
        public Nullable<int> PrevRef { get; set; }
        public Nullable<int> NextRef { get; set; }
        public string InvoiceRef { get; set; }
        public Nullable<int> RepeatCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArTransPost> ArTransPosts { get; set; }
        public virtual ArTransStatus ArTransStatu { get; set; }
        public virtual ArAccount ArAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArAction> ArActions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArTransPayment> ArTransPayments { get; set; }
        public virtual ArCategory ArCategory { get; set; }
    }
}

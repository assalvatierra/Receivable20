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
    
    public partial class ArAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArAccount()
        {
            this.ArTransactions = new HashSet<ArTransaction>();
            this.ArPayments = new HashSet<ArPayment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Landline { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public int ArAccStatusId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArTransaction> ArTransactions { get; set; }
        public virtual ArAccStatus ArAccStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArPayment> ArPayments { get; set; }
    }
}
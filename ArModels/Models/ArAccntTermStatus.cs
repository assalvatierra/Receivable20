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
    
    public partial class ArAccntTermStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArAccntTermStatus()
        {
            this.ArAccntPaymentTerms = new HashSet<ArAccntTerm>();
        }
    
        public int Id { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArAccntTerm> ArAccntPaymentTerms { get; set; }
    }
}

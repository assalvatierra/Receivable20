//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ArActionItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArActionItem()
        {
            this.ArActions = new HashSet<ArAction>();
        }
    
        public int Id { get; set; }
        public string Action { get; set; }
        public string Remarks { get; set; }
        public decimal SortNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArAction> ArActions { get; set; }
    }
}

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
    
    public partial class ArTransPayment
    {
        public int Id { get; set; }
        public int ArTransactionId { get; set; }
        public int ArPaymentId { get; set; }
    
        public virtual ArTransaction ArTransaction { get; set; }
        public virtual ArPayment ArPayment { get; set; }
    }
}

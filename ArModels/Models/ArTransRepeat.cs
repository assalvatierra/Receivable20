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
    
    public partial class ArTransRepeat
    {
        public int Id { get; set; }
        public int PrevRef { get; set; }
        public int NextRef { get; set; }
        public int RepeatCount { get; set; }
        public int RpeatNo { get; set; }
        public int Interval { get; set; }
    
        public virtual ArTransaction ArTransaction { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TanarKilistazo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orarendek
    {
        public System.Guid ID { get; set; }
        public System.Guid Osztaly { get; set; }
        public System.Guid Tanterem { get; set; }
        public System.Guid Tanar { get; set; }
        public System.Guid Tantargy { get; set; }
        public int Nap { get; set; }
        public int Ora { get; set; }
    
        public virtual Osztalyok Osztalyok { get; set; }
        public virtual Tanarok Tanarok { get; set; }
        public virtual Tantargyak Tantargyak { get; set; }
        public virtual Tantermek Tantermek { get; set; }
    }
}

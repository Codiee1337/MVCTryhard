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
    
    public partial class Tantermek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tantermek()
        {
            this.Orarendek = new HashSet<Orarendek>();
        }
    
        public System.Guid ID { get; set; }
        public string Tanteremnev { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orarendek> Orarendek { get; set; }
    }
}

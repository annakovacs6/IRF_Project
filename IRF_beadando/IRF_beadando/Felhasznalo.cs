//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IRF_beadando
{
    using System;
    using System.Collections.Generic;
    
    public partial class Felhasznalo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Felhasznalo()
        {
            this.Budapest_10km = new HashSet<Budapest_10km>();
            this.Idomero = new HashSet<Idomero>();
            this.Mikulas_futas = new HashSet<Mikulas_futas>();
            this.Nyar_koszonto_futas = new HashSet<Nyar_koszonto_futas>();
        }
    
        public string FELH_NEV { get; set; }
        public string NEV { get; set; }
        public System.DateTime SZUL_DAT { get; set; }
        public string LAKCIM { get; set; }
        public string FUTO_AZONOSITO { get; set; }
        public string EMAIL { get; set; }
        public string JELSZO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budapest_10km> Budapest_10km { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Idomero> Idomero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mikulas_futas> Mikulas_futas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nyar_koszonto_futas> Nyar_koszonto_futas { get; set; }
    }
}

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
    
    public partial class Budapest_10km
    {
        public int HELYEZES { get; set; }
        public string FELH_NEV_FK { get; set; }
        public System.TimeSpan IDO { get; set; }
        public string ESEMENY_FK { get; set; }
        public string TAV { get; set; }
    
        public virtual Esemeny Esemeny { get; set; }
        public virtual Felhasznalo Felhasznalo { get; set; }
    }
}

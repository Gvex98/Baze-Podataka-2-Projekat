//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BioskopData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Karta
    {
        public int Id { get; set; }
        public int BrojSedista { get; set; }
        public int Cena { get; set; }
        public int KupacId { get; set; }
        public int ProjekcijaId { get; set; }
        public Nullable<int> ProdavacJMBG { get; set; }
    
        public virtual Kupac Kupac { get; set; }
        public virtual Projekcija Projekcija { get; set; }
        public virtual Prodavac Prodavac { get; set; }
    }
}

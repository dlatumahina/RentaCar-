//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentaCar.Models
{
    using System;
    
    public partial class GetOrderInfo_Result
    {
        public string Klantcode { get; set; }
        public string Naam { get; set; }
        public string Factuurnummer { get; set; }
        public string Kenteken { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public string Periode { get; set; }
        public string Medewerker { get; set; }
        public Nullable<decimal> totaal { get; set; }
        public Nullable<System.DateTime> datum { get; set; }
        public Nullable<decimal> factuurtotaal { get; set; }
    }
}
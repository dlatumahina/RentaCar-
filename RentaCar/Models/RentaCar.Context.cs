﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RentaCarEntities : DbContext
    {
        public RentaCarEntities()
            : base("name=RentaCarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<auto> auto { get; set; }
        public virtual DbSet<factuur> factuur { get; set; }
        public virtual DbSet<factuurregel> factuurregel { get; set; }
        public virtual DbSet<klant> klant { get; set; }
        public virtual DbSet<medewerker> medewerker { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    
        public virtual int AddOrder(string oRDERID, Nullable<System.DateTime> oRDERDATE, string eMPLOYEEID, string cUSTOMERID)
        {
            var oRDERIDParameter = oRDERID != null ?
                new ObjectParameter("ORDERID", oRDERID) :
                new ObjectParameter("ORDERID", typeof(string));
    
            var oRDERDATEParameter = oRDERDATE.HasValue ?
                new ObjectParameter("ORDERDATE", oRDERDATE) :
                new ObjectParameter("ORDERDATE", typeof(System.DateTime));
    
            var eMPLOYEEIDParameter = eMPLOYEEID != null ?
                new ObjectParameter("EMPLOYEEID", eMPLOYEEID) :
                new ObjectParameter("EMPLOYEEID", typeof(string));
    
            var cUSTOMERIDParameter = cUSTOMERID != null ?
                new ObjectParameter("CUSTOMERID", cUSTOMERID) :
                new ObjectParameter("CUSTOMERID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddOrder", oRDERIDParameter, oRDERDATEParameter, eMPLOYEEIDParameter, cUSTOMERIDParameter);
        }
    
        public virtual int AddOrderItem(string oRDERID, string lICENSE, Nullable<System.DateTime> sTARTDATE, Nullable<System.DateTime> eNDDATE, Nullable<decimal> dAYPRICE)
        {
            var oRDERIDParameter = oRDERID != null ?
                new ObjectParameter("ORDERID", oRDERID) :
                new ObjectParameter("ORDERID", typeof(string));
    
            var lICENSEParameter = lICENSE != null ?
                new ObjectParameter("LICENSE", lICENSE) :
                new ObjectParameter("LICENSE", typeof(string));
    
            var sTARTDATEParameter = sTARTDATE.HasValue ?
                new ObjectParameter("STARTDATE", sTARTDATE) :
                new ObjectParameter("STARTDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            var dAYPRICEParameter = dAYPRICE.HasValue ?
                new ObjectParameter("DAYPRICE", dAYPRICE) :
                new ObjectParameter("DAYPRICE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddOrderItem", oRDERIDParameter, lICENSEParameter, sTARTDATEParameter, eNDDATEParameter, dAYPRICEParameter);
        }
    
        public virtual ObjectResult<GetOrderInfo_Result> GetOrderInfo(string oRDERID)
        {
            var oRDERIDParameter = oRDERID != null ?
                new ObjectParameter("ORDERID", oRDERID) :
                new ObjectParameter("ORDERID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrderInfo_Result>("GetOrderInfo", oRDERIDParameter);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCEFDFCrudWebsiteDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GN22ADMDNF001Entities : DbContext
    {
        public GN22ADMDNF001Entities()
            : base("name=GN22ADMDNF001Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
    }
}

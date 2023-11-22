﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TAJMAC99dbEntities : DbContext
    {
        public TAJMAC99dbEntities()
            : base("name=TAJMAC99dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adminSystem> adminSystems { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<customersAdmin> customersAdmins { get; set; }
        public virtual DbSet<customerSystem> customerSystems { get; set; }
        public virtual DbSet<Log_In> Log_In { get; set; }
        public virtual DbSet<systemsDetail> systemsDetails { get; set; }
    
        public virtual ObjectResult<adminSysDetail_Result> adminSysDetail(Nullable<int> adminId)
        {
            var adminIdParameter = adminId.HasValue ?
                new ObjectParameter("adminId", adminId) :
                new ObjectParameter("adminId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<adminSysDetail_Result>("adminSysDetail", adminIdParameter);
        }
    }
}

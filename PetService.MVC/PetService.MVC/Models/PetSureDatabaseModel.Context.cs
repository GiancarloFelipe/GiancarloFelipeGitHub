﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetService.MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PetSureDatabaseEntities : DbContext
    {
        public PetSureDatabaseEntities()
            : base("name=PetSureDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PetClaimService> PetClaimServices { get; set; }
        public DbSet<PetClaimServiceTemp> PetClaimServiceTemps { get; set; }
        public DbSet<PetList> PetLists { get; set; }
    }
}

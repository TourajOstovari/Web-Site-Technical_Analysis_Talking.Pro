﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Technical_Analysis_Talking.Pro.App_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database_StructContainer : DbContext
    {
        public Database_StructContainer()
            : base("name=Database_StructContainer")
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<Database_StructContainer>());
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Posts_> Posts_Set { get; set; }
        public virtual DbSet<Users_> Users_Set { get; set; }
        public virtual DbSet<news_subscribe> news_subscribe { get; set; }
        public virtual DbSet<Interest_rate> Interest_rate { get; set; }
    }
}

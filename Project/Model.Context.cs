﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user2Entities : DbContext
    {
        public user2Entities()
            : base("name=user2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookingStol> BookingStol { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Razdeli> Razdeli { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Stoli> Stoli { get; set; }
        public virtual DbSet<ZakazBluda> ZakazBluda { get; set; }
        public virtual DbSet<Zakazi> Zakazi { get; set; }
    }
}

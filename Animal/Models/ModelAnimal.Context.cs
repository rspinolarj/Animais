﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Animal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bancoAnimalEntities : DbContext
    {
        public bancoAnimalEntities()
            : base("name=bancoAnimalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Especie> Especie { get; set; }
        public virtual DbSet<IdentificadorAnimal> IdentificadorAnimal { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<StatusAnimal> StatusAnimal { get; set; }
        public virtual DbSet<TipoIdentificador> TipoIdentificador { get; set; }
    }
}
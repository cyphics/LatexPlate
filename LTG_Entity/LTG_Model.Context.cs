﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LTG_Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LTGEntities : DbContext
    {
        public LTGEntities()
            : base("name=LTGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Environment> Environments { get; set; }
        public virtual DbSet<Langue> Langues { get; set; }
        public virtual DbSet<Macro> Macroes { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateEnvironment> TemplateEnvironments { get; set; }
        public virtual DbSet<TemplateMacro> TemplateMacroes { get; set; }
        public virtual DbSet<TemplateMeta> TemplateMetas { get; set; }
        public virtual DbSet<TemplatePackage> TemplatePackages { get; set; }
        public virtual DbSet<ScanDir> ScanDirs { get; set; }
    }
}

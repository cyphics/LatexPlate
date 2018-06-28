//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Template()
        {
            this.TemplateEnvironments = new HashSet<TemplateEnvironment>();
            this.TemplateMacroes = new HashSet<TemplateMacro>();
            this.TemplateMetas = new HashSet<TemplateMeta>();
            this.TemplatePackages = new HashSet<TemplatePackage>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Desc { get; set; }
        public int LangueID { get; set; }
        public int DocTypeID { get; set; }
        public Nullable<bool> Hyperref { get; set; }
        public Nullable<bool> Encoding { get; set; }
    
        public virtual DocType DocType { get; set; }
        public virtual Langue Langue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemplateEnvironment> TemplateEnvironments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemplateMacro> TemplateMacroes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemplateMeta> TemplateMetas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemplatePackage> TemplatePackages { get; set; }
    }
}

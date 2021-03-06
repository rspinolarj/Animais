//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            this.IdentificadorAnimal = new HashSet<IdentificadorAnimal>();
        }
    
        public int idAnimal { get; set; }
        public Nullable<short> Esp_idEspecie { get; set; }
        public Nullable<byte> sex_idSexo { get; set; }
        public Nullable<byte> StA_idStatusAnimal { get; set; }
    
        public virtual Especie Especie { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual StatusAnimal StatusAnimal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdentificadorAnimal> IdentificadorAnimal { get; set; }
    }
}

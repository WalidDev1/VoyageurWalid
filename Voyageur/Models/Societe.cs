//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Voyageur.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Societe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Societe()
        {
            this.cars = new HashSet<car>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public int id_user { get; set; }
        public int tel { get; set; }
        public string adresse { get; set; }
        public string mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<car> cars { get; set; }
        public virtual User User { get; set; }
    }
}

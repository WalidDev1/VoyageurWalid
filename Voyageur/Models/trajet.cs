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
    
    public partial class trajet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trajet()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int id { get; set; }
        public int id_ville_depart { get; set; }
        public int id_ville_destination { get; set; }
        public decimal prix { get; set; }
        public System.DateTime date_depart { get; set; }
        public System.DateTime date_arrivée { get; set; }
        public int id_car { get; set; }
    
        public virtual car car { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual Ville Ville { get; set; }
        public virtual Ville Ville1 { get; set; }
    }
}

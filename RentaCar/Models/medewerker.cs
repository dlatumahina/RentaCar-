//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentaCar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class medewerker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medewerker()
        {
            this.factuur = new HashSet<factuur>();
            this.klant = new HashSet<klant>();
        }
    
        public string medewerkerscode { get; set; }
        public string voorletters { get; set; }
        public string tussenvoegsels { get; set; }
        public string achternaam { get; set; }
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }
        public string naam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factuur> factuur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klant> klant { get; set; }
    }
}

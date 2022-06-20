namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cActualAdress")]
    public partial class cActualAdress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cActualAdress()
        {
            vCitizen = new HashSet<vCitizen>();
        }

        public int Id { get; set; }

        [StringLength(512)]
        public string FullAdress { get; set; }

        public int PostCodeId { get; set; }

        public virtual cPostCode cPostCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vCitizen> vCitizen { get; set; }
    }
}

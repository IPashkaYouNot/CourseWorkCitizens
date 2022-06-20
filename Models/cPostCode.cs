namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cPostCode")]
    public partial class cPostCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cPostCode()
        {
            cActualAdress = new HashSet<cActualAdress>();
            cRegistrationAdress = new HashSet<cRegistrationAdress>();
        }

        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public int SettlementId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cActualAdress> cActualAdress { get; set; }

        public virtual cSettlement cSettlement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cRegistrationAdress> cRegistrationAdress { get; set; }
    }
}

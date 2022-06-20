namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cDistrict")]
    public partial class cDistrict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cDistrict()
        {
            cSettlement = new HashSet<cSettlement>();
        }

        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public int AdministrativeUnitId { get; set; }

        public virtual cAdministrativeUnit cAdministrativeUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cSettlement> cSettlement { get; set; }
    }
}

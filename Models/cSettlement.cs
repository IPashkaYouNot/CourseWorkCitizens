namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cSettlement")]
    public partial class cSettlement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cSettlement()
        {
            cPostCode = new HashSet<cPostCode>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string NumberCode { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public int? DistrictId { get; set; }

        public int? AdministrativeUnitId { get; set; }

        public virtual cAdministrativeUnit cAdministrativeUnit { get; set; }

        public virtual cDistrict cDistrict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cPostCode> cPostCode { get; set; }
    }
}

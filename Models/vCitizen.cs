namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vCitizen")]
    public partial class vCitizen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vCitizen()
        {
            cMobilePhone = new HashSet<cMobilePhone>();
            vDocument = new HashSet<vDocument>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string IPNCode { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Surname { get; set; }

        [StringLength(64)]
        public string Patronymic { get; set; }

        [StringLength(6)]
        public string HomeNumber { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime BirthDate { get; set; }

        public int RegistrationAdress { get; set; }

        public int ActualAdress { get; set; }

        public virtual cActualAdress cActualAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cMobilePhone> cMobilePhone { get; set; }

        public virtual cRegistrationAdress cRegistrationAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vDocument> vDocument { get; set; }
    }
}

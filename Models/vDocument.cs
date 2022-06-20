namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vDocument")]
    public partial class vDocument
    {
        [Key]
        [StringLength(9)]
        public string DocumentId { get; set; }

        [Required]
        [StringLength(4)]
        public string DepartmentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int CitizenId { get; set; }

        public virtual vCitizen vCitizen { get; set; }
    }
}

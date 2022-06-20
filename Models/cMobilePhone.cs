namespace kr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cMobilePhone")]
    public partial class cMobilePhone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string Number { get; set; }

        public int? Citizen { get; set; }

        public virtual vCitizen vCitizen { get; set; }
    }
}

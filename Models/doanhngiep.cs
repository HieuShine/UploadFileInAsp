namespace uploadFile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("doanhngiep")]
    public partial class doanhngiep
    {
        [Key]
        public int idDN { get; set; }

        [StringLength(255)]
        public string tenDN { get; set; }

        public int? id { get; set; }

        public virtual tailieudinhkem tailieudinhkem { get; set; }
    }
}

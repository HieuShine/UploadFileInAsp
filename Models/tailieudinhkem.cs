namespace uploadFile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tailieudinhkem")]
    public partial class tailieudinhkem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tailieudinhkem()
        {
            doanhngieps = new HashSet<doanhngiep>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string DuongDan { get; set; }
        public string filePdf { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doanhngiep> doanhngieps { get; set; }
    }
}

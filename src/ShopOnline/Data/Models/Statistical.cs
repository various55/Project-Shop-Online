namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statistical")]
    public partial class Statistical
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}

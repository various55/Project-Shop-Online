namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageDetail")]
    public partial class ImageDetail
    {
        [Key]
        public int ID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(256)]
        public string Url { get; set; }

        public virtual Product Product { get; set; }

    }
}

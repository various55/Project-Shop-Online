namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDetail")]
    public partial class ProductDetail
    {
        [Key]
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? SizeID { get; set; }

        public int? ColorID { get; set; }

        [StringLength(256)]
        public string UrlImage { get; set; }

        public int? Invenory { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }

    }
}

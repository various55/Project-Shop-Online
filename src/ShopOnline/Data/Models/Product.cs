namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public Product()
        {
            Discount = 0;
            TotalPurchase = 0;
            TotalPurchase = 0;
            ImportPrice = 0;
            ExportPrice = 0;
            Status = true;
            ShowOnHome = true;
        }

        [Key]
        public int ID { get; set; }

        [StringLength(12)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        public int? SupplierID { get; set; }

        [StringLength(256)]
        public string UrlImage { get; set; }

        public double? ImportPrice { get; set; }

        public double? ExportPrice { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public double? Discount { get; set; }

        public int? TotalPurchase { get; set; }

        public int? TotalInventory { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }

        public virtual ICollection<ImageDetail> ImageDetails { get; set; }
        public virtual Category Category { get; set; }
        public virtual Suppelier Suppelier { get; set; }
    }
}

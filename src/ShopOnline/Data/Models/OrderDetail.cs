namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetai")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductDetaiID { get; set; }

        public double? Price { get; set; }

        public int? Quantity { get; set; }

        public double? Discount { get; set; }

        public double? Total { get; set; }

        public virtual Order Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}

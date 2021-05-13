namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string Payment { get; set; }

        public double? Total { get; set; }

        public double? Fee { get; set; }

        public double? Discount { get; set; }

        public bool? Status { get; set; }

        public int? ConfirmStatusId { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey("UserID")]
        public virtual User UserMember { get; set; }

        public virtual ConfirmStatus ConfirmStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetais { get; set; }

    }
}

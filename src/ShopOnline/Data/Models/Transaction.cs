namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [Key]
        public int ID { get; set; }

        public int? OrderID { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateAt { get; set; }

        [StringLength(256)]
        public string Note { get; set; }

        public bool? Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }

    }
}

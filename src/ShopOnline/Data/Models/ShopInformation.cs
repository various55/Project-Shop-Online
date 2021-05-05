namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopInformation")]
    public partial class ShopInformation
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Logo { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Moblie { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Facebook { get; set; }

        [StringLength(50)]
        public string Instagram { get; set; }

        [StringLength(50)]
        public string Twitter { get; set; }

        [StringLength(50)]
        public string Youtube { get; set; }

        [StringLength(50)]
        public string Zalo { get; set; }
    }
}

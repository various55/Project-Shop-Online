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

        public string Logo { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        public string Address { get; set; }

        [StringLength(15)]
        public string Moblie { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Twitter { get; set; }

        public string Youtube { get; set; }

        public string Zalo { get; set; }
    }
}

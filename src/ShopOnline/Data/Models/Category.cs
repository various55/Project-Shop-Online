namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

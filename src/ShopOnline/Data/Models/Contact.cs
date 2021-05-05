namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}

namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyAt { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User user { get; set; }
    }
}

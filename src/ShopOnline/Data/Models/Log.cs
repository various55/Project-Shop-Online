namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public Log()
        {
            Status = true;
            CreateAt = DateTime.Now;
        }

        [Key]
        public int ID { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreateAt { get; set; }

        public bool? Status { get; set; }
    }
}

namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConfirmStatus
    {
        [Key]
        public int ID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}

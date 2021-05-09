using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
   public class LogDTO
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreateAt { get; set; }

        public bool? Status { get; set; }
    }
}

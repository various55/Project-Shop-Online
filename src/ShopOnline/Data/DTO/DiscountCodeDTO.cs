using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
   public class DiscountCodeDTO
    {
        public int ID { get; set; }
        public string Code { get; set; }
        // OO thieeu truong giam bao nhieu % a
        [Range(0,100)]
        public int? Discount { get; set; }

        public string Detail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User User { get; set; }
    }
}

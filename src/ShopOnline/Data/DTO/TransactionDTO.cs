using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class TransactionDTO
    {

        public int? OrderID { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateAt { get; set; }

        public string Note { get; set; }

        public bool? Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
  public class ProductDetaiDTO
    {
        [Key]
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? SizeID { get; set; }

        public int? ColorID { get; set; }

        [StringLength(256)]
        public string UrlImage { get; set; }

        public int? Invenory { get; set; }
        
    }
}

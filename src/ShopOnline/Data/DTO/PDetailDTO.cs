using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class PDetailDTO
    {
        public int ID { get; set; }
        [StringLength(256)]
        public string UrlImage { get; set; }

        public int? Invenory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
       
    }
}

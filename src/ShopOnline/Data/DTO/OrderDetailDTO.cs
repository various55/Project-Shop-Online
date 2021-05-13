using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class OrderDetailDTO
    {
        public virtual ProductDetail ProductDetail { get; set; }

        public double? Price { get; set; }

        public int? Quantity { get; set; }

        public double? Discount { get; set; }

        public double? Total { get; set; }

    }
}

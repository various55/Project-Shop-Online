using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name="Tên khách hàng")]
        public string Name { get; set; }

        [StringLength(256)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(15)]
        public string Mobile { get; set; }

        
        [Display(Name = "Phương thức thanh toán")]
        [StringLength(50)]
        public string Payment { get; set; }

        [Display(Name = "Tổng tiền")]
        public double? Total { get; set; }

        [Display(Name = "Phí")]

        public double? Fee { get; set; }

        public double? Discount { get; set; }

        [Display(Name = "Trạng thái")]
        public string ConfirmStatusName { get; set; }

    }
}

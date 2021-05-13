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
        [Required]
        [Display(Name="Tên khách hàng")]
        public string Name { get; set; }

        [StringLength(256)]
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Display(Name="Ngày order")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Phương thức thanh toán")]
        [StringLength(50)]
        public string Payment { get; set; }

        [Display(Name = "Tổng tiền")]
        public double? Total { get; set; }

        public String CodeDiscount { get; set; }

        [Display(Name = "Phí")]

        public double? Fee { get; set; }

        public double? Discount { get; set; }

        [Display(Name = "Trạng thái")]
        public string ConfirmStatusName { get; set; }

        [Display(Name="Danh sách sản phẩm")]
        public virtual ICollection<OrderDetail> OrderDetais { get; set; }
        public virtual ConfirmStatus ConfirmStatus { get; set; }

    }
}

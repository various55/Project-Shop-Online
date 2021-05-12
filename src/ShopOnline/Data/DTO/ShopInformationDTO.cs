using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class ShopInformationDTO
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên shop")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name = "Mã số thuế")]
        [StringLength(50)]
        public string TaxCode { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        [StringLength(15)]
        public string Moblie { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [StringLength(50)]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        [StringLength(50)]
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [StringLength(50)]
        [Display(Name = "Youtube")]
        public string Youtube { get; set; }

        [StringLength(50)]
        [Display(Name = "Zalo")]
        public string Zalo { get; set; }
    }
}

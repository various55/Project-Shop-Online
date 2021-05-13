using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class ContactDTO
    {
        public ContactDTO()
        {
            CreatedAt = DateTime.Now;
        }

       
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ và tên:")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string Mobile { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Thời gian tạo:")]
        public DateTime? CreatedAt { get; set; }
    }
}


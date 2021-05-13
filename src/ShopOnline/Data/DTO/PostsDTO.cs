using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class PostsDTO
    {

        public PostsDTO()
        {
            Status = true;
            CreatedAt = DateTime.Now;
            ModifyAt = DateTime.Now;
        }

        public int ID { get; set; }
        [Display(Name = "Tiêu đề")]

        public string Title { get; set; }

        [StringLength(256)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [StringLength(256)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }
        [Display(Name = "Người tạo")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Thời gian  tạo")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Người chỉnh sửa")]
        public int? ModifyBy { get; set; }
        [Display(Name = "Thời gian chỉnh sửa")]
        public DateTime? ModifyAt { get; set; }

        public virtual User user { get; set; }


    }
}

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
        

        public string Title { get; set; }

        [StringLength(256)]
        [Display(Name = "Tiêu đề")]
        public string Image { get; set; }

        [StringLength(256)]
        [Display(Name = "Ảnh")]
        public string Description { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
        [Display(Name = "Nội dung")]
        public bool? Status { get; set; }
        [Display(Name = "Trạng thái")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Người tạo")]
        public DateTime? CreatedAt { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyAt { get; set; }

        public virtual User user { get; set; }


    }
}

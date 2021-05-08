using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
   public class SuppelierDTO
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Bạn phải nhập tên")]
        
        public string Name { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage ="Bạn phải nhập địa chỉ")]
        public string Andress { get; set; }
        [StringLength(15)]
        [Required(ErrorMessage ="Bạn phải nhập số điện thoại")]
        [Phone(ErrorMessage ="Là kiểu số bạn ơi!!!")]
        public string Mobile { get; set; }

        [StringLength(50)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        [Required]
        public string Manager { get; set; }


    }
}

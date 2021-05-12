using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserPasswordDTO
    {
        public string Username { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = ("Mật khẩu hiện tại"))]
        public string Password { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = ("Mật khẩu mới"))]
        public string NewPassword { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = ("Mật khẩu mới"))]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        
    }
}

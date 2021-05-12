using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserRegistDTO
    {
        [StringLength(50)]
        [Display(Name = ("Tài khoản"))]
        public string Username { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = ("Mật khẩu"))]
        public string Password { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = ("Nhập Lại mật khẩu"))]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

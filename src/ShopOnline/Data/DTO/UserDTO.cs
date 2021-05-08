using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserDTO
    {

        [StringLength(50)]
        [Display(Name =("Tài khoản"))]
        public string Username { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = ("Mật khẩu"))]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = ("Họ và tên"))]
        public string Name { get; set; }

        [StringLength(256)]
        [Display(Name = ("Địa chỉ"))]
        public string Address { get; set; }

        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = ("Số điện thoại"))]
        public string Mobile { get; set; }

        [StringLength(50)]
        [Display(Name = ("Email"))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}

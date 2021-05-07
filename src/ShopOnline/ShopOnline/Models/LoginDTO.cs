using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Remmember { get; set; }
    }
}
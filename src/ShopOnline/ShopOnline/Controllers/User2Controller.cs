using Business.Services;
using Constants;
using Data.DTO;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopOnline.Controllers
{
    public class User2Controller : Controller
    {
        IUserService userService;

        public User2Controller()
        {

        }
        public User2Controller(IUserService userService)
        {
            this.userService = userService;
        }


        // GET: User2
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var res = userService.Login(username, MD5.CreateMD5(password));
                if (res != null)
                {
                    var role = res.Role.Name;
                    if (role != RoleConst.CUSTOMER) ModelState.AddModelError("", "Chỉ tài khoản customer mới có quyền truy cập !!!");
                    else
                    {
                        FormsAuthentication.SetAuthCookie(username, true);
                        Response.Cookies[CookieConst.USER].Value = res.ID.ToString();
                        Response.Cookies[CookieConst.USER].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies[CookieConst.ROLE].Value = res.Role.Name;
                        Response.Cookies[CookieConst.USER].Expires = DateTime.Now.AddDays(1);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies[CookieConst.USER].Expires = DateTime.Now.AddDays(-2);
            Response.Cookies[CookieConst.ROLE].Expires = DateTime.Now.AddDays(-2);
            return RedirectToAction("Index", "User2");
        }
        public ActionResult GetUser()
        {
            var username = User.Identity.Name;
            if (username != null)
            {
                var user = userService.FindByUsername(username);
                var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
                return PartialView("Layout/UserPartial", userDTO);
            }
            return Redirect("/");
        }
    }
}
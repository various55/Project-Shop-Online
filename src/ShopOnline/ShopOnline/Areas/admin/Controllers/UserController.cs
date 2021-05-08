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

namespace ShopOnline.Areas.admin.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController()
        {

        }
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: admin/User
        public ActionResult Index()
        {
            var isLogin = HttpContext.User.Identity.IsAuthenticated;
            if (isLogin) return Redirect("/");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                var res = userService.Login(username, MD5.CreateMD5(password));
                if (res!=null)
                {
                    var role = res.Role.Name;
                    if(role==RoleConst.CUSTOMER) ModelState.AddModelError("", "Tài khoản của bạn không có đủ quyền truy cập");
                    else
                    {
                        //SessionHelper.SetSession(new UserSession() { UserName = model.Username });
                        FormsAuthentication.SetAuthCookie(username, true);
                        Response.Cookies[CookieConst.USER].Value = res.ID.ToString();
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
            return RedirectToAction("Index", "User");
        }
        public ActionResult GetUser()
        {
            var id = Request.Cookies.Get(CookieConst.USER);
            if(id != null)
            {
                var user = userService.FindById(Int32.Parse(id.Value));
                var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
                return PartialView("Layout/UserPartial", userDTO);
            }
            return Redirect("/");
        }

    }
}
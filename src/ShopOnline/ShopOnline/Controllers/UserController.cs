using Business.Services;
using Constants;
using Data.DTO;
using Data.Models;
using Helpers;
using ShopOnline.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopOnline.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
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
                if (res != null) { 
                    var role = res.Role.Name;
                        FormsAuthentication.SetAuthCookie(username, true);
                        Response.Cookies[CookieConst.USER].Value = res.ID.ToString();
                        Response.Cookies[CookieConst.USER].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies[CookieConst.ROLE].Value = res.Role.Name;
                        Response.Cookies[CookieConst.USER].Expires = DateTime.Now.AddDays(1);
                        return RedirectToAction("Index", "Home");
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
            var username = User.Identity.Name;
            if (username != null)
            {
                var user = userService.FindByUsername(username);
                var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
                return PartialView("Layout/UserPartial", userDTO);
            }
            return Redirect("/");
        }

        [CustomAuthorize("MEMBER")]
        // GET: User
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult InfoUser()
        {
            var id = int.Parse(Request.Cookies[CookieConst.USER].Value);

            var user = userService.FindById(id);

            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);

            return PartialView(userDTO);
        }

        public ActionResult UpdateBillInfo()
        {
            var id = int.Parse(Request.Cookies[CookieConst.USER].Value);

            User user = userService.FindById(id);
            

            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);

            return PartialView(userDTO);
        }
        [HttpPost]
        public ActionResult EditBillInfo(UserDTO model)
        {
            var id = int.Parse(Request.Cookies[CookieConst.USER].Value);
            var status = false;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<Data.Models.User>(model);

                user.ID = id;
                status = userService.EditBillInfo(user);

                userService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadFromChangePassword()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ChangePassword(UserPasswordDTO model)
        {
            var id = int.Parse(Request.Cookies[CookieConst.USER].Value);
            var status = false;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                if (model.ConfirmNewPassword == model.NewPassword)
                    status = userService.ChangePass(id, MD5.CreateMD5(model.NewPassword), MD5.CreateMD5(model.Password));

                userService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FromRegistUser()
        {
            return PartialView();
        }

        public ActionResult registUser(UserRegistDTO model)
        {
            var status = false;
            string msg = "";

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Username = model.Username;
                user.Password = MD5.CreateMD5(model.Password);

                if (model.ConfirmPassword == model.Password)
                {
                    // Đăng ký thiếu file r, mai bảo Khanh
                    //msg = userService.RegistUser(user);
                    if (msg.Length == 0) status = true;
                }


                userService.Save();
            }
            return Json(new { status, msg }, JsonRequestBehavior.AllowGet);
        }

    }
}
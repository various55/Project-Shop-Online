using Business.Services;
using Constants;
using Data.DTO;
using Data.Models;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: User
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult InfoUser()
        {
            var user = userService.FindById(1);

            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);

            return PartialView(userDTO);
        }

        public ActionResult UpdateBillInfo(int id)
        {
            User user;
            if (id != 0)
                user = userService.FindById(1);
            else
                user = new User();

            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);

            return PartialView(userDTO);
        }
        [HttpPost]
        public ActionResult EditBillInfo(UserDTO model)
        {
            var id=int.Parse(Request.Cookies[CookieConst.USER].Value);
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
            var id=int.Parse(Request.Cookies[CookieConst.USER].Value);
            var status = false;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                if(model.ConfirmNewPassword==model.NewPassword)
                    status = userService.ChangePass(id, MD5.CreateMD5(model.NewPassword),MD5.CreateMD5(model.Password));

                userService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

    }
}
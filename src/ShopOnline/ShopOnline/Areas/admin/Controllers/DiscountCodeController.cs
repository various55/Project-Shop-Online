using Business.Services;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    [Authorize]
    public class DiscountCodeController : Controller
    {
        IDiscountCodeService discountCodeService;
        IUserService userService;
        public DiscountCodeController()
        {

        }
        public DiscountCodeController(IDiscountCodeService discountCodeService, IUserService userService)
        {
            this.discountCodeService = discountCodeService;
            this.userService = userService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAll()
        {
            var discountCodes = discountCodeService.FindAll();
            var discounts = AutoMapper.Mapper.Map<IEnumerable<DiscountCodeDTO>>(discountCodes);
            return PartialView("DiscountCode/_DiscountCodePartial", discounts);
        }
        public ActionResult FormAddOrUpdate(int id)
        {
            var model = discountCodeService.FindById(id);
            var dto = AutoMapper.Mapper.Map<DiscountCodeDTO>(model);
            return PartialView("DiscountCode/_DiscountCodeDetailPartial", dto);
        }
        public ActionResult Delete(int id)
        {
            var res = discountCodeService.Remove(id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddOrUpdate(DiscountCodeDTO data)
        {
            var status = false;
            data.CreatedAt = DateTime.Now;
            var username = User.Identity.Name;
            data.CreatedBy = userService.FindAll().Where(x => x.Username == username).FirstOrDefault().ID;
            if (ModelState.IsValid)
            {

                var model = AutoMapper.Mapper.Map<DiscountCode>(data);
                if (data.ID == 0)
                {
                  status= discountCodeService.Add(model);
                }
                else
                {
                  status= discountCodeService.Update(model);
                }
                discountCodeService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsValid(string code)
        {
            var res = false;
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
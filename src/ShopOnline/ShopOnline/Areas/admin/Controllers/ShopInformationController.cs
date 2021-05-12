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
    public class ShopInformationController : Controller

    {
        IShopInformationService ShopInformationservice;
        public ShopInformationController()
        {

        }
        public ShopInformationController(IShopInformationService ShopInformationservice)
        {
            this.ShopInformationservice = ShopInformationservice;
        }

        // GET: admin/ShopInformation
        public ActionResult Index()
        {
            var ShopInformation = ShopInformationservice.FindAll();
            // Phải chuyền sang DTO 
            ICollection<ShopInformationDTO> ShopInformationDTO = AutoMapper.Mapper.Map<ICollection<ShopInformationDTO>>(ShopInformation);
            return View(ShopInformationDTO);

        }
        [HttpGet]
        public PartialViewResult ListShopInformation()
        {
            var ShopInformation = ShopInformationservice.FindAll();
            var ShopInformationDTO = AutoMapper.Mapper.Map<ICollection<ShopInformationDTO>>(ShopInformation);
            return PartialView(ShopInformationDTO);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = ShopInformationservice.Remove(id);
            ShopInformationservice.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult AddOrUpdate(ShopInformationDTO model)
        {
            
            var status = false;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                ShopInformation ShopInformation = new ShopInformation();
                ShopInformation = AutoMapper.Mapper.Map<ShopInformation>(model);
                if (model.ID == 0)
                {
                    status = ShopInformationservice.Add(ShopInformation);
                }
                else { status = ShopInformationservice.Update(ShopInformation); }
                ShopInformationservice.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var ShopInformation = ShopInformationservice.FindById(id);
            var ShopInformationDTO = AutoMapper.Mapper.Map<ShopInformationDTO>(ShopInformation);
            ViewBag.Data = ShopInformationDTO;
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult InfoDetail(int id)
        {
            var ShopInformation = ShopInformationservice.FindById(id);
            var ShopInformationDTO = AutoMapper.Mapper.Map<ShopInformationDTO>(ShopInformation);
            return PartialView(ShopInformationDTO);
        }
    }
}

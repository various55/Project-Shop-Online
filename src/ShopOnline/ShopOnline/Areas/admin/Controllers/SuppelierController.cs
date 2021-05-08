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
    public class SuppelierController : Controller
    { // GET: admin/ // GET: admin/Suppelier
        ISuppelierService suppelierService;
        public SuppelierController()
        {

        }
        public SuppelierController(ISuppelierService suppelierService)
        {
            this.suppelierService = suppelierService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public JsonResult AddOrUpdate(SuppelierDTO model)
        {
            var status = false;
            if (ModelState.IsValid)
            {
                Suppelier Suppeliery = new Suppelier();
                Suppeliery.ID = model.ID;
                Suppeliery.Name = model.Name;
                Suppeliery.Andress = model.Andress;
                Suppeliery.Mobile = model.Mobile;
                Suppeliery.Email = model.Email;
                Suppeliery.Manager = model.Manager;


                if (model.ID == 0)
                {
                    status= suppelierService.Add(Suppeliery);
                }
                else
                {
                    status= suppelierService.Update(Suppeliery);
                }
                suppelierService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var Suppelier = suppelierService.FindById(id);
            var SuppelierDTO = AutoMapper.Mapper.Map<SuppelierDTO>(Suppelier);
            ViewBag.Data = SuppelierDTO;
            return PartialView();
        }
       
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = suppelierService.Remove(id);
            suppelierService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult InfoDetail(int id)
        {
            var Suppelier = suppelierService.FindById(id);
            var SuppelierDTO = AutoMapper.Mapper.Map<SuppelierDTO>(Suppelier);
            return PartialView(SuppelierDTO);
        }
        public ActionResult listSuppelier()
        {
            var Suppelier = suppelierService.FindAll();
            var SuppelierDTO = AutoMapper.Mapper.Map<ICollection<SuppelierDTO>>(Suppelier);
            return PartialView(SuppelierDTO);
        }
       
        
        
      
        
       
      
    }
}
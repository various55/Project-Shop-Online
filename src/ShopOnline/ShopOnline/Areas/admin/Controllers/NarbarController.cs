/*using Business.Services;
using Data.DTO;
using Data.Models;
using ShopOnline.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    [Authorize]
    [CustomAuthorize("ADMIN,STAFF")]
    public class NarbarController : Controller
    {
        INarbarService narbarService;

        public NarbarController() { }
        public NarbarController(INarbarService narbarService)
        {
            this.narbarService = narbarService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult listNarbar()
        {
            var narbars = narbarService.FindAll();
            var narbarDTOs = AutoMapper.Mapper.Map<IEnumerable<NarbarDTO>>(narbars);
            return PartialView(narbarDTOs);
        }
        [HttpPost]
        public JsonResult AddOrUpdate(NarbarDTO model)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            if (ModelState.IsValid)
            {
                Narbar narbar = new Narbar();
                narbar = AutoMapper.Mapper.Map<Narbar>(model);
                if (model.ID == 0)
                {
                    status = narbarService.Add(narbar);
                }
                else { status = narbarService.Update(narbar); }
                narbarService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var narbar = narbarService.FindById(id);
            var narbarDTO = AutoMapper.Mapper.Map<NarbarDTO>(narbar);
            ViewBag.Data = narbarDTO;
            return PartialView();
        }
    }
}*/
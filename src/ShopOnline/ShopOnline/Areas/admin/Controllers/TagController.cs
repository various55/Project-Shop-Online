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
    public class TagController : Controller
    {
        ITagsService tagService;
        public TagController()
        {

        }
        public TagController(ITagsService tagService)
        {
            this.tagService = tagService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
         
            return View();
        }
        [HttpPost]
        public JsonResult AddOrUpdate(TagDTO model)
        {
            var status = false;
            if (ModelState.IsValid)
            {
                Tag tag = new Tag();
                tag.ID = model.ID;
                tag.Name = model.Name;
                tag.Detail = model.Detail;

                if (model.ID == 0)
                {
                   status= tagService.Add(tag);
                }
                else
                {
                   status= tagService.Update(tag);
                }
                tagService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var tag = tagService.FindById(id);
            var tagDTO = AutoMapper.Mapper.Map<TagDTO>(tag);
            ViewBag.Data = tagDTO;
            return PartialView();
        }
       
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = tagService.Remove(id);
            tagService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listTag()
        {
            var tags = tagService.FindAll();
            var tagsDTO = AutoMapper.Mapper.Map<ICollection<TagDTO>>(tags);
            return PartialView(tagsDTO);
        }
    }
}
using Business.Services;
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
    public class CategoryController : Controller
    {
        // GET: admin/Category
        ICategoryService categoryService;
        public CategoryController()
        {

        }
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
            // Đổ dữ liệu model
            //var category = categoryService.FindAll();
            //// Phải chuyền sang DTO 
            //ICollection<CategoryDTO> orderDTO = AutoMapper.Mapper.Map<ICollection<CategoryDTO>>(category);
            //return View(orderDTO);
            return View();
        }
        [HttpPost]
        public JsonResult AddOrUpdate(CategoryDTO model)
        {
            var status = true;
            if (ModelState.IsValid) {
                Category category = new Category();
                category.ID = model.ID;
                category.Name = model.Name;
                category.Status = model.Status;

                if (model.ID == 0)
                {
                    categoryService.Add(category);
                }
                else
                {
                    categoryService.Update(category);
                }
                categoryService.Save();
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var category = categoryService.FindById(id);
            var categoryDTO = AutoMapper.Mapper.Map<CategoryDTO>(category);
            ViewBag.Data = categoryDTO;
            return PartialView();
        }
       
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = categoryService.Remove(id);
            categoryService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listCategory()
        {
            var categories = categoryService.FindAll();
            var categoriesDTO = AutoMapper.Mapper.Map<ICollection<CategoryDTO>>(categories);
            return PartialView(categoriesDTO);
        }
    }
}
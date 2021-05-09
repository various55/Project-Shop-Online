using Business.Services;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService categoryService;
        public HomeController()
        {

        }
        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

       public PartialViewResult Sale()
        {
            return PartialView();
        }
        public PartialViewResult Banner()
        {
            return PartialView();
        }
        public PartialViewResult BannerFooter()
        {
            return PartialView();
        }
        public PartialViewResult BlogLeft()
        {
            return PartialView();
        }
        public ActionResult CategoriesLeft()
        {
            var categories = categoryService.FindAll();
            var categoriDTO = AutoMapper.Mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return PartialView(categoriDTO);
        }
        public PartialViewResult Product()
        {
            return PartialView();
        }
        public PartialViewResult LeftFooter()
        {
            return PartialView();
        }
        public PartialViewResult Left()
        {
            return PartialView();
        }
       
    }
}
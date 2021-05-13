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
        IProductService productService;
        public HomeController()
        {

        }
        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
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
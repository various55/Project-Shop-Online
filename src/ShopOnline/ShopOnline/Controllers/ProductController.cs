using Business.Services;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;

        public ProductController()
        {

        }

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = productService.FindAll();
            return View();
        }
        public ActionResult ProductDetail()
        {
            return View();
        }
    }
}
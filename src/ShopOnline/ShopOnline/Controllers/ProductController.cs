using Business.Services;
using Data.DTO;
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
        ICategoryService categoryService;
        IProductDetailService productDetailService;
        public ProductController()
        {

        }

        public ProductController(IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.productDetailService = productDetailService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(int id)
        {
            var productDetail = productDetailService.Find(id);
            var productDetailDTO = AutoMapper.Mapper.Map<ICollection<PDetailDTO>>(productDetail);
            var product = productService.FindById(id);
            ViewBag.product= AutoMapper.Mapper.Map<ProductDTO>(product);
            return View(productDetailDTO);
        }
      
        public ActionResult listCategory()
        {
            var categories = categoryService.FindAll();
            var categoriDTO = AutoMapper.Mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return PartialView(categoriDTO);
        }
        public ActionResult Product(int idCategory, int pageNumber, int pageSize, string search)
        {
            var products = productService.FindAll();
            ViewBag.idCategory = idCategory;
            
            if (idCategory == 0)
            {
                if (search.Trim() != "") products = products.Where(x => x.Name.Contains(search)).OrderBy(x => x.Name).ToList();
            }
            else
            {
                if (search.Trim() != "") products = products.Where(x => x.Name.Contains(search)).OrderBy(x => x.Name).ToList();
                products = productService.FindByCategory(idCategory);
            }
            var productDTO = AutoMapper.Mapper.Map<IEnumerable<ProductDTO>>(products);
            var pageCount = Math.Ceiling((double)products.Count() / pageSize);
            ViewBag.pageCount = pageCount;
            if (pageCount >= pageNumber)
            {
                var model = productDTO.OrderBy(x => x.Name).Skip(pageSize * pageNumber - pageSize).Take(pageSize).ToList();
                ViewBag.pageNumber = pageNumber;
                return PartialView(model);
            }

            return PartialView(productDTO);


        }
    }
}
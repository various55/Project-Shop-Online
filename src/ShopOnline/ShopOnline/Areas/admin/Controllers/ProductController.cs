﻿using Business.Services;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
      
        IProductService productService;
        ICategoryService categoryService;
        ISuppelierService suppelierService;
        IProductDetailService productDetailService;
        IColorService colorService;
        ISizeService sizeService;
        public ProductController()
        {

        }
        public ProductController(IProductService productService, ICategoryService categoryService, ISuppelierService suppelierService, IProductDetailService productDetailService, IColorService colorService, ISizeService sizeService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.suppelierService = suppelierService;
            this.productDetailService = productDetailService;
            this.colorService = colorService;
            this.sizeService = sizeService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public JsonResult AddOrUpdate(ProductDTO model)
        {
            var status = false;
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //}
            //if (ModelState.IsValid)
            //{
                Product product = new Product();
                product = AutoMapper.Mapper.Map<Product>(model);
            
                if (model.ID == 0)
                {
                   status= productService.Add(product);
                }
                else
                {
                   status= productService.Update(product);
                }
                productService.Save();
           // }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FormProductDetail(int id)
        {
            var product = productService.FindById(id);
            var ProductDTO = AutoMapper.Mapper.Map<ProductDTO>(product);
            ViewBag.Data = ProductDTO;
            ViewBag.Size = AutoMapper.Mapper.Map<IEnumerable<SizeDTO>>(sizeService.FindAll());
            ViewBag.Color = AutoMapper.Mapper.Map<IEnumerable<ColorDTO>>(colorService.FindAll());
            return PartialView();
        }
        [HttpPost]
        public JsonResult AddProductDetail(ProductDetaiDTO model)
        {
            ProductDetail product = new ProductDetail();
            product.ID = model.ID;
            product.ProductID = model.ProductID;
            product.SizeID = model.SizeID;
            product.ColorID = model.SizeID;
            product.UrlImage = model.UrlImage;
            product.Invenory = model.Invenory;
            bool status = false;
            status = productDetailService.Add(product);
            productDetailService.Save();
           
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {

            var product = productService.FindById(id);
            var ProductDTO  = AutoMapper.Mapper.Map<ProductDTO>(product);
            ViewBag.Data = ProductDTO;
            var category = categoryService.FindAll();
            ViewBag.Category = AutoMapper.Mapper.Map<IEnumerable<CategoryDTO>>(category);
            var supplier = suppelierService.FindAll();
            ViewBag.Supplier = AutoMapper.Mapper.Map<IEnumerable<SuppelierDTO>>(supplier);
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult Detail(int id)
        {
            //t muốn kết hợp giữa lấy theo id và join vs các bảng 
            Product product = productService.FindById(id);
            var productDetail = productService.FindAll(new string[] { "product", "Color", "Size" });

            var ProductsDTO = AutoMapper.Mapper.Map<ICollection<PDetailDTO>>(productDetail);
            return PartialView();
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = productService.Delete(id);
            productService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listProduct()
        {
            var product = productService.FindAll();
            var ProductsDTO = AutoMapper.Mapper.Map<ICollection<ProductDTO>>(product);
            return PartialView(ProductsDTO);
        }
        public ActionResult listProductDetail()
        {
            var productDetail = productDetailService.FindAll(new string[] { "Product","Color","Size" });
           
            var ProductsDTO = AutoMapper.Mapper.Map<ICollection<PDetailDTO>>(productDetail);
            return PartialView(ProductsDTO);
        }
        [HttpPost]
        public JsonResult DeletePDetail(int id)
        {
            var status = productDetailService.Delete(id);
            productDetailService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
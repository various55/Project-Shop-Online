using Business.Services;
using Data.DTO;
using Data.Models;
using Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductDetailService productDetailService;
        private readonly IProductService productService;
        public CartController()
        {

        }
        public CartController(IOrderService orderService,
            IProductDetailService productDetailService,
            IProductService productService)
        {
            this.orderService = orderService;
            this.productDetailService = productDetailService;
            this.productService = productService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCode(string code)
        {
            var status = code == "ABCD1234";
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Checkout(OrderDTO orderDTO)
        {
            var status = false;
            var cart = ShoppingCart.Cart;
            var order = AutoMapper.Mapper.Map<Order>(orderDTO);
            // Lấy ra thông tin order detail
            order.OrderDetais = cart.Items;
            // Lấy code kiểm tra
            order.Discount = 0;
            order.Fee = order.Fee;
            order.Total = cart.Total() * (1.0 - order.Discount/100) + order.Fee;
            status = orderService.Add(order);
            orderService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int id, string action, int? size=1, int? color=1, int? quantity=1)
        {
            bool status = false;
            var carts = ShoppingCart.Cart;
            var product = productService.FindById(id);
            if (product == null) return Json(status, JsonRequestBehavior.AllowGet);
            else
            {
                var productDetail = productDetailService.Find(id, (int)size, (int)color);
                if (productDetail != null)
                {
                    switch (action)
                    {
                        case "update":
                            status = carts.Update(productDetail.ID, (int)quantity);
                            break;
                        case "delete":
                            status = carts.Remove(productDetail.ID);
                            break;
                        case "add":
                            status = carts.Add(productDetail.ID, (int)quantity);
                            break;
                        default:
                            break;
                    }
                }
            }

            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadAll()
        {
            var carts = ShoppingCart.Cart.Items;
            var cartDTO = AutoMapper.Mapper.Map<List<OrderDetailDTO>>(carts);
            // return Mutil partialview
            var quickCartPartial = ViewToString.RenderRazorViewToString(this.ControllerContext,"Cart/_QuickCart",cartDTO);
            var cartPartial = ViewToString.RenderRazorViewToString(this.ControllerContext,"Cart/_Cart",cartDTO);
            var json = Json(new { quickCartPartial, cartPartial }, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}
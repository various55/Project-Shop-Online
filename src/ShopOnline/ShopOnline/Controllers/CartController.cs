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
        private readonly IDiscountCodeService discountCodeService;
        private readonly IUserService userService;
        public CartController()
        {

        }
        public CartController(IOrderService orderService,
            IProductDetailService productDetailService,
            IProductService productService,
            IDiscountCodeService discountCodeService,
            IUserService userService)
        {
            this.orderService = orderService;
            this.productDetailService = productDetailService;
            this.productService = productService;
            this.discountCodeService = discountCodeService;
            this.userService = userService;
        }

        // GET: Cart
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var user = userService.FindByUsername(username);
            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
            return View(userDTO);
        }
        [HttpPost]
        public ActionResult GetCode(string code)
        {
            var cart = ShoppingCart.Cart;
            var total = cart.Total();
            var status = false;
            var save = 0;
            int discount = 0;
            if (!string.IsNullOrEmpty(code))
            {
                discount = discountCodeService.getDiscountByCode(code);
                status = discount > 0;
                if (status) cart.discount = discount > 0 ? discount : 0;
                var totalDiscount = cart.Total() * (1 - discount / 100.0);
                save = (int)(total - totalDiscount);
            }
            var json = Json(new { status, discount, total, save }, JsonRequestBehavior.AllowGet);
            return json;
        }
        [HttpPost]

        public ActionResult Checkout(OrderDTO orderDTO)
        {
            var user = userService.FindByUsername(User.Identity.Name);
            var status = false;
            var cart = ShoppingCart.Cart;
            var order = AutoMapper.Mapper.Map<Order>(orderDTO);
            // Lấy ra thông tin order detail
            order.OrderDetais = cart.Items;
            // Lấy code kiểm tra
            order.Discount = cart.discount;
            order.Fee = order.Fee ?? 0;
            order.Total = cart.Total() * (1 - order.Discount / 100.0) + order.Fee;
            order.ConfirmStatusId = 1;
            order.CreatedAt = DateTime.Now;
            order.Payment = "Thanh toán tiền mặt !";
            order.Status = true;
            order.UserID = user.ID;
            status = orderService.Add(order);
            if (status) cart.Items.Clear();
            orderService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(int id, string action, int? size = 1, int? color = 1, int? quantity = 1)
        {

            bool status = false;
            var carts = ShoppingCart.Cart;
            if (action == "delete")
            {
                status = carts.Remove(id);
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            else if (action == "update")
            {
                status = carts.Update(id, (int)quantity);
            }
            else
            {
                var p = productDetailService.Find(id,(int) size,(int) color);
                if (p == null) status = false;
                else
                    status = carts.Add(p.ID, (int)quantity);
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadAll()
        {
            var carts = ShoppingCart.Cart.Items;
            var cartModel = (ICollection<OrderDetail>)carts;
            foreach (var item in cartModel)
            {
                var test = productDetailService.FindById(item.ProductDetaiID);
                item.ProductDetail = productDetailService.FindById(item.ProductDetaiID);
            }
            ViewBag.Discount = ShoppingCart.Cart.discount;
            var cartDTO = AutoMapper.Mapper.Map<IEnumerable<OrderDetailDTO>>(cartModel);
            // return Mutil partialview
            var quickCart = ViewToString.RenderRazorViewToString(this.ControllerContext, "_QuickCartPartial", cartDTO);
            var cart = ViewToString.RenderRazorViewToString(this.ControllerContext, "Cart/_Cart", cartDTO);
            var json = Json(new { quickCart, cart }, JsonRequestBehavior.AllowGet);
            return json;
        }
        public ActionResult Clear()
        {
            var carts = ShoppingCart.Cart.Items;
            if (carts != null) carts.Clear();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
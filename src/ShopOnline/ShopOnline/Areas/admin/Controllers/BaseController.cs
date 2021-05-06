using Business.Services;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        IOrderService orderService;
        public BaseController()
        {

        }
        public BaseController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
            // Đổ dữ liệu model
            var orders = orderService.FindAll();
            // Phải chuyền sang DTO 
            ICollection<OrderDTO> orderDTO = AutoMapper.Mapper.Map<ICollection<OrderDTO>>(orders);
            return View(orderDTO);
        }
    }
}
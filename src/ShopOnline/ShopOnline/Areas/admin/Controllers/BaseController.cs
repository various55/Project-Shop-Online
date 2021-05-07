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
        [HttpPost]
        public JsonResult AddOrUpdate(OrderDTO model)
        {
            var status = true;
            model.ConfirmStatusName = "Thanh toán tiền mặt";
            Order order = new Order();
            order.ID = model.ID;
            order.Name = model.Name;
            order.Address = model.Address;
            order.Mobile = model.Mobile;
            order.ConfirmStatusId = 1;
            if (model.ID == 0)
            {
                orderService.Add(order);
            }
            else
            {
                orderService.Update(order);
            }
            orderService.Save();

            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult FromCreateUpdate(int id)
        {
            var order = orderService.FindById(id);
            var orderDTO = AutoMapper.Mapper.Map<OrderDTO>(order);
            ViewBag.Data = orderDTO;
            return PartialView();
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var status = orderService.Remove(id);
            orderService.Save();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listbase()
        {
            var orders = orderService.FindAll();
            var orderDTO = AutoMapper.Mapper.Map<ICollection<OrderDTO>>(orders);
            return PartialView(orderDTO);
        }
    }
}
using Business.Services;
using Constants;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        IOrderDetailService orderDetailService;
        IProductDetailService productDetailService;
        ITransactionService transactionService;
        IUserService userService;
        public OrderController()
        {

        }
        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService,
            IProductDetailService productDetailService,ITransactionService transactionService,
            IUserService userService)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.productDetailService = productDetailService;
            this.transactionService = transactionService;
            this.userService = userService;
        }

        // GET: admin/Order
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadAll()
        {
            var orders = orderService.FindAll().Where(x=>x.Status==true);
            foreach(var o in orders)
            {
                foreach (var i in o.OrderDetais)
                {
                    i.ProductDetail = productDetailService.FindByProduct(i.ProductDetaiID);
                }
            }
            var ordersDTO = AutoMapper.Mapper.Map<IEnumerable<OrderDTO>>(orders);
            return PartialView("OrderAdmin/_OrderPartial", ordersDTO);
        }
        public ActionResult LoadOrderDetail(int id)
        {
            var order = orderService.FindById(id);
            var details = order.OrderDetais = orderDetailService.FindByOrderId(id);
            foreach(var item in details)
            {
                item.ProductDetail = productDetailService.FindByProduct(item.ProductDetaiID);
            }
            var orderDTO = AutoMapper.Mapper.Map<OrderDTO>(order);
            return PartialView("OrderAdmin/_OrderDetailParial", orderDTO);
        }
        [HttpPost]
        public ActionResult Confirm(int id,string note,bool status)
        {
            var res = false;
            Transaction transaction = new Transaction();
            transaction.OrderID = id;
            transaction.Note = note;
            transaction.Status = status;
            var idUser = userService.FindByUsername(User.Identity.Name).ID;
            transaction.CreateBy = idUser;
            res = transactionService.Add(transaction);
            // chuyển trạng thái order
            var order = orderService.FindById(id);
            order.Status = false;
            orderService.Update(order);
            transactionService.Save();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
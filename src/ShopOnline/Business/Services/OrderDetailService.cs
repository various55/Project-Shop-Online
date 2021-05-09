using Data.Models;
using Data.Repositories;
using Data.Repositories.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IOrderDetailService
    {
        ICollection<OrderDetail> FindAll();
        ICollection<OrderDetail> FindByOrderId(int id);
    }
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailRepository orderDetailRepository;
        IUnitOfWork unitOfWork;
        public OrderDetailService()
        {

        }
        public OrderDetailService(IOrderDetailRepository orderDetailRepository,
        IUnitOfWork unitOfWork)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<OrderDetail> FindAll()
        {
            return orderDetailRepository.findAll(new string[] { "Product", "Size", "Color" });
    }

        public ICollection<OrderDetail> FindByOrderId(int id)
        {
            return orderDetailRepository.findByCondition(x => x.OrderID == id);
        }
    }
}

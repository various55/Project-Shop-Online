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
    // File ví dụ hướng dẫn làm
    public interface IBaseService
    {
        ICollection<Order> FindAll();
        Order FindByUserId(int id);
        Order FindById(int id);
        ICollection<Order> FindByEmail(string email);
        ICollection<Order> FindByTotal(float total);
        bool Add(Order order);
        bool Remove(int id);

        bool Update(Order order);
        void Save();
    }
    public class BaseService : IBaseService
    {
        public IOrderRepository OrderRepository;
        public IUserRepository userRepository;

        public IUnitOfWork unitOfWork;

        public BaseService()
        {

        }
        public BaseService(IOrderRepository OrderRepository,IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.OrderRepository = OrderRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }


        public ICollection<Order> FindAll()
        {
            return OrderRepository.findAll(new string[] { "UserMember" });
        }
        public Order FindById(int id)
        {
            return OrderRepository.findById(id);
        }
        // Tìm tất cả các order của user có id
        public Order FindByUserId(int id)
        {
            // findByCondition: Tìm kiếm theo điều kiện
            var orders = OrderRepository.findByCondition(o => o.UserID == id).FirstOrDefault();
            return orders;
        }
        // Tìm tất cả các order của user có email là abc@gmail.com
        public ICollection<Order> FindByEmail(string email)
        {
            // findByCondition: Tìm kiếm theo điều kiện, nhưng mà email nó k nằm trong order
            var orders = OrderRepository.findByCondition(o => o.UserMember.Email.Contains(email),new string[] { "UserMember" });
            return orders;
        }
        public ICollection<Order> FindByTotal(float total)
        {
            // findByCondition: Tìm kiếm theo điều kiện, nhưng mà email nó k nằm trong order
            var orders = OrderRepository.findByCondition(o => o.Total>total, new string[] { "UserMember" });
            return orders;
        }
        public bool Add(Order order)
        {
            var res = OrderRepository.add(order);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = OrderRepository.delete(id);
            return res != null;
        }
        public bool Update(Order order)
        {
            return OrderRepository.update(order);
        }

        public void Save()
        {
            unitOfWork.commit();
        }
    }
}

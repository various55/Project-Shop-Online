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
    public interface IDiscountCodeService
    {
        int getDiscountByCode(string code);

        ICollection<DiscountCode> FindAll(string[] includes=null);
        ICollection<DiscountCode> FindAll();
        DiscountCode FindById(int id);
        ICollection<DiscountCode> FindByDate();
        bool Add(DiscountCode discountCode);
        bool Remove(int id);

        bool Update(DiscountCode discountCode);
        void Save();
    }
    public class DiscountCodeService : IDiscountCodeService
    {
        public IDiscountCodeRepository DiscountCodeRepository;//thiếu cái này
       
        public IUnitOfWork unitOfWork;

        public DiscountCodeService()
        {

        }
        public DiscountCodeService(IDiscountCodeRepository DiscountCodeRepository,
            IUnitOfWork unitOfWork)
        {
            this.DiscountCodeRepository = DiscountCodeRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<DiscountCode> FindAll()
        {
            var order = DiscountCodeRepository.findAll();
            return order;
        }
        public ICollection<DiscountCode> FindAll(string[] includes=null)
        {
            var order = DiscountCodeRepository.findAll(includes);
            return order;
        }
    
     
        // Tìm tất cả các order của user có email là abc@gmail.com
        public ICollection<DiscountCode> FindByDate()
        {
            // findByCondition: Tìm kiếm theo điều kiện, nhưng mà email nó k nằm trong order
            var a = DateTime.Now.Ticks;
            var discountCode = DiscountCodeRepository.findByCondition(o=>o.StartTime.Ticks<=DateTime.Now.Ticks && o.EndTime.Ticks>=DateTime.Now.Ticks);

            return discountCode;
        }
       
        public bool Add(DiscountCode discountCode)
        {
            var res = DiscountCodeRepository.add(discountCode);
          
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = DiscountCodeRepository.delete(id);
            return res != null;
        }
        public bool Update(DiscountCode discountCode)
        {
            return DiscountCodeRepository.update(discountCode);
        }

        public void Save()
        {
            unitOfWork.commit();
        }

        public DiscountCode FindById(int id)
        {
            return DiscountCodeRepository.findById(id);
        }

        public int getDiscountByCode(string code)
        {
            var model = DiscountCodeRepository.findByCondition(x => x.Code == code && x.EndTime > DateTime.Now).SingleOrDefault();
            if (model == null) return 0;
            return (int)model.Discount;
        }
    }
}

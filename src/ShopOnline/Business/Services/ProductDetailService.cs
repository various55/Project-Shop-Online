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
    public interface IProductDetailService
    {
        ProductDetail Find(int id, int size, int color);
        ProductDetail FindByProduct(int id);
        void Save();
    }
    public class ProductDetailService : IProductDetailService
    {
        IProductDetailRepository productDetailRepository;
        IUnitOfWork unitOfWork;

        public ProductDetailService()
        {

        }
        public ProductDetailService(IProductDetailRepository productDetailRepository,
        IUnitOfWork unitOfWork)
        {
            this.productDetailRepository = productDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        public ProductDetail Find(int id, int size, int color)
        {
            return productDetailRepository.Find(id,size,color);
        }
        public ProductDetail FindByProduct(int id)
        {
            return productDetailRepository.findAll(new string[] { "Product", "Color", "Size" }).SingleOrDefault(x=>x.ID==id);
        }

        public void Save()
        {
            unitOfWork.commit();
        }

    }
}

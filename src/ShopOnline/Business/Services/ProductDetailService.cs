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
        bool Add(ProductDetail product);
        bool Update(ProductDetail product);
        bool Delete(int id);
        ICollection<ProductDetail> FindAll();
        ICollection<ProductDetail> FindAll(string[] includes);
        ProductDetail FindById(int id);
      
        void Save();
    }
    public class ProductDetailService: IProductDetailService
    {
        public IProductDetailRepository productRepository;

        public IUnitOfWork unitOfWork;

        public ProductDetailService()
        {

        }
        public ProductDetailService(IProductDetailRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Add(ProductDetail product)
        {
            var res = productRepository.add(product);
            return res != null;
        }

        public bool Delete(int id)
        {
            var res = productRepository.delete(id);
            return res!=null;
        }
        public bool Update(ProductDetail product)
        {
            var res = productRepository.update(product);
            return res;
        }

        public ICollection<ProductDetail> FindAll()
        {
            var products = productRepository.findAll();
            return products;
        }

        public ICollection<ProductDetail> FindAll(string[] includes )
        {
            var products = productRepository.findAll(includes);
            return products;
        }
        public ProductDetail FindById(int id)
        {
            return productRepository.findById(id);
        }
        public void Save()
        {
            unitOfWork.commit();
        }
    }
}

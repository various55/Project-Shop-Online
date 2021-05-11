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
            return productDetailRepository.Find(id, size, color);
        }
        public bool Add(ProductDetail product)
        {
            var res = productDetailRepository.add(product);
            return res != null;
        }

        public bool Delete(int id)
        {
            var res = productDetailRepository.delete(id);
            return res != null;
        }
        public bool Update(ProductDetail product)
        {
            var res = productDetailRepository.update(product);
            return res;
        }

        public ICollection<ProductDetail> FindAll()
        {
            var products = productDetailRepository.findAll();
            return products;
        }
        public ProductDetail FindByProduct(int id)
        {
            return productDetailRepository.findAll(new string[] { "Product", "Color", "Size" }).SingleOrDefault(x => x.ID == id);
        }

        public ICollection<ProductDetail> FindAll(string[] includes)
        {
            var products = productDetailRepository.findAll(includes);
            return products;
        }
        public ProductDetail FindById(int id)
        {
            return productDetailRepository.findById(id);
        }
        public void Save()
        {
            unitOfWork.commit();
        }

    }
}

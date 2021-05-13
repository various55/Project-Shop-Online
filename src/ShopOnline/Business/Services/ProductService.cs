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
    public interface IProductService
    {
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(int id);
        ICollection<Product> FindAll();
        ICollection<Product> FindAll(string[] includes);
        Product FindById(int id);
        ICollection<Product> FindByCategory(int id);
        ICollection<Product> FindBySupplier(int id);
        void Save();
    }
    public class ProductService : IProductService
    {
        public IProductRepository productRepository;

        public IUnitOfWork unitOfWork;

        public ProductService()
        {

        }
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Add(Product product)
        {
            var res = productRepository.add(product);
            return res != null;
        }

        public bool Delete(int id)
        {
            var res = productRepository.delete(id);
            return res == null;
        }
        public bool Update(Product product)
        {
           var res= productRepository.update(product);
            return res;
        }

        public ICollection<Product> FindAll()
        {
            var products = productRepository.findAll();
            return products;
        }

        public ICollection<Product> FindAll(string[] includes)
        {
            var products = productRepository.findAll(includes);
            return products;
        }

        public ICollection<Product> FindByCategory(int id)
        {
            // Làm theo cái này, join thì join cái kia, findByCondition này tìm theo nhiều điều kiện + join đc nhiều bảng đc, kieeru ddaasy
            var products = productRepository.findByCondition(x => x.CategoryID == id  , new string[] { "Color","Size","ProductDetail" });
            return products;
        }

        public Product FindById(int id)
        {
            return productRepository.findById(id);
        }

        public ICollection<Product> FindBySupplier(int id)
        {
            var products = productRepository.findByCondition(x => x.SupplierID == id, new string[] { "Category" });
            return products;
        }

        public void Save()
        {
            unitOfWork.commit();
        }
    }
}

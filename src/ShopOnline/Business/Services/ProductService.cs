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
        void Update(Product product);
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
        public IProductRepository _productRepository;

        public IUnitOfWork _unitOfWork;

        public ProductService()
        {

        }
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Product product)
        {
            var res = _productRepository.add(product);
            return res != null;
        }

        public bool Delete(int id)
        {
            var res = _productRepository.delete(id);
            return res == null;
        }
        public void Update(Product product)
        {
            _productRepository.update(product);
        }

        public ICollection<Product> FindAll()
        {
            var products = _productRepository.findAll();
            return products;
        }

        public ICollection<Product> FindAll(string[] includes)
        {
            var products = _productRepository.findAll(includes);
            return products;
        }

        public ICollection<Product> FindByCategory(int id)
        {
            var products = _productRepository.findByCondition(x => x.CategoryID == id, new string[] { "Category" });
            return products;
        }

        public Product FindById(int id)
        {
            return _productRepository.findById(id);
        }

        public ICollection<Product> FindBySupplier(int id)
        {
            var products = _productRepository.findByCondition(x => x.SupplierID == id, new string[] { "Category" });
            return products;
        }

        public void Save()
        {
            _unitOfWork.commit();
        }
    }
}

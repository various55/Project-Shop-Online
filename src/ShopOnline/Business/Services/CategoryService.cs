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
    public interface ICategoryService
    {
        ICollection<Category> FindAll();
       
        Category FindById(int id);
       
        bool Add(Category category);
        bool Remove(int id);

        bool Update(Category category);
        void Save();
    }
    class CategoryService: ICategoryService
    {
        public ICategoryRepository CategoryRepository;
        public IUserRepository userRepository;

        public IUnitOfWork unitOfWork;

        public CategoryService()
        {

        }
        public CategoryService(ICategoryRepository CategoryRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.CategoryRepository = CategoryRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }


        public ICollection<Category> FindAll()
        {
            return CategoryRepository.findAll();
        }
        public Category FindById(int id)
        {
            return CategoryRepository.findById(id);
        }
        // Tìm tất cả các order của user có id
       
        // Tìm tất cả các order của user có email là abc@gmail.com
       
        
        public bool Add(Category category)
        {
            var res = CategoryRepository.add(category);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = CategoryRepository.delete(id);
            return res != null;
        }
        public bool Update(Category category)
        {
            return CategoryRepository.update(category);
        }

        public void Save()
        {
            unitOfWork.commit();
        }

       
    }
}

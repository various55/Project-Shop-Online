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
    public interface IPostService
    {

        ICollection<Post> FindAll();
      
        Post FindById(int id);
      
        bool Add(Post post);
        bool Remove(int id);

        bool Update(Post post);
        void Save();
    }
    public class PostService : IPostService
    {
        public IPostRepository PostRepository;
        public IUserRepository userRepository;

        public IUnitOfWork unitOfWork;
        public PostService()
        {

        }
        public PostService(IPostRepository PostRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.PostRepository = PostRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }


        public ICollection<Post> FindAll()
        {
            return PostRepository.findAll();
           /* var x = PostRepository.findAll();
            return PostRepository.findAll(new string[] { "user" });*/
        }
        public Post FindById(int id)
        {
            return PostRepository.findById(id);
        }
       
      
        public bool Add(Post post)
        {
            var res = PostRepository.add(post);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = PostRepository.delete(id);
            return res != null;
        }
        public bool Update(Post post)
        {
            return PostRepository.update(post);
        }

        public void Save()
        {
            unitOfWork.commit();
        }
    }
}

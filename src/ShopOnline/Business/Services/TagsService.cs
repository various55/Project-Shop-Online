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
    public interface ITagsService
    {
        bool Add(Tag tag);
        bool Update(Tag tag);
        bool Remove(int id);
        ICollection<Tag> FindAll();
       
        Tag FindById(int id);
       
        void Save();
    }
   public class TagsService: ITagsService
    {
        public ITagRepository TagRepository;
        public IUserRepository userRepository;

        public IUnitOfWork unitOfWork;

        public TagsService()
        {

        }
        public TagsService(ITagRepository TagRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.TagRepository = TagRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }


        public ICollection<Tag> FindAll()
        {
            return TagRepository.findAll();
        }
        public Tag FindById(int id)
        {
            return TagRepository.findById(id);
        }
       

        public bool Add(Tag tag)
        {
            var res = TagRepository.add(tag);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = TagRepository.delete(id);
            return res != null;
        }
        public bool Update(Tag tag)
        {
            return TagRepository.update(tag);
        }

        public void Save()
        {
            unitOfWork.commit();
        }

    }
}

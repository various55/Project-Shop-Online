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
    public interface ISuppelierService
    {
        ICollection<Suppelier> FindAll();

        Suppelier FindById(int id);

        bool Add(Suppelier Suppelier);
        bool Remove(int id);

        bool Update(Suppelier Suppelier);
        void Save();
    }
    public class SuppelierService : ISuppelierService
    {
        public ISuppelierRepository SuppelierRepository;
        public IUserRepository userRepository;

        public IUnitOfWork unitOfWork;

        public SuppelierService()
        {

        }
        public SuppelierService(ISuppelierRepository SuppelierRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.SuppelierRepository = SuppelierRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }


        public ICollection<Suppelier> FindAll()
        {
            return SuppelierRepository.findAll();
        }
        public Suppelier FindById(int id)
        {
            return SuppelierRepository.findById(id);
        }
        // Tìm tất cả các order của user có id

        // Tìm tất cả các order của user có email là abc@gmail.com


        public bool Add(Suppelier Suppelier)
        {
            var res = SuppelierRepository.add(Suppelier);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = SuppelierRepository.delete(id);
            return res != null;
        }
        public bool Update(Suppelier Suppelier)
        {
            return SuppelierRepository.update(Suppelier);
        }

        public void Save()
        {
            unitOfWork.commit();
        }


    }
}


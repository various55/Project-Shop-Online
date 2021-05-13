/*using Data.Models;
using Data.Repositories;
using Data.Repositories.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface INarbarService
    {
        ICollection<Narbar> FindAll();
       
        bool Add(Narbar narbar);
        bool Remove(int id);
        Narbar FindById(int id);

        bool Update(Narbar narbar);
        void Save();
    }
     public class NarbarService:INarbarService
    {
        public INarbarRepository narbarRepository;
       
        public IUnitOfWork unitOfWork;

        public NarbarService()
        {

        }
        public NarbarService(INarbarRepository narbarRepository, IUnitOfWork unitOfWork)
        {
            this.narbarRepository = narbarRepository;
            this.unitOfWork = unitOfWork;
           
        }


        public ICollection<Narbar> FindAll()
        {
            return narbarRepository.findAll();
        }

        public Narbar FindById(int id)
        {
            return narbarRepository.findById(id);
        }

        public bool Add(Narbar narbar)
        {
            var res = narbarRepository.add(narbar);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = narbarRepository.delete(id);
            return res != null;
        }
        public bool Update(Narbar narbar)
        {
            return narbarRepository.update(narbar);
        }

        public void Save()
        {
            unitOfWork.commit();
        }
    }
}
*/
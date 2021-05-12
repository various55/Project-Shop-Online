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
    public interface IContactService
    {
        ICollection<Contact> FindAll();

        Contact FindById(int id);

        bool Add(Contact contact);
        bool Remove(int id);

        bool Update(Contact contact);
        void Save();
    }
    public class ContactService : IContactService
    {
        public IContactRepository ContactRepository;
        public IUserRepository userRepository;

        public IUnitOfWork unitOfWork;
        public ContactService()
        {

        }
        public ContactService(IContactRepository ContactRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.ContactRepository = ContactRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }


        public ICollection<Contact> FindAll()
        {
            var x = ContactRepository.findAll();
            return x;
        }
        public Contact FindById(int id)
        {
            return ContactRepository.findById(id);
        }


        public bool Add(Contact contact)
        {
            var res = ContactRepository.add(contact);
            return res != null;
        }
        public bool Remove(int id)
        {
            var res = ContactRepository.delete(id);
            return res != null;
        }
        public bool Update(Contact contact)
        {
            return ContactRepository.update(contact);
        }

        public void Save()
        {
            unitOfWork.commit();
        }
    }
}

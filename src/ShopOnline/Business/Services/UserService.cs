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
    public interface IUserService
    {
        bool Add(User User);
        bool Update(User User);
        bool Delete(int id);
        ICollection<User> FindAll();
        ICollection<User> FindAll(string[] includes);
        User FindById(int id);
        User Login(string username,string password);
        User FindByUsername(string username);
        void Save();
    }
    public class UserService : IUserService
    {
        public IUserRepository _UserRepository;

        public IUnitOfWork _unitOfWork;

        public UserService()
        {

        }
        public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork)
        {
            this._UserRepository = UserRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(User User)
        {
            var res = _UserRepository.add(User);
            return res != null;
        }

        public bool Delete(int id)
        {
            var res = _UserRepository.delete(id);
            return res == null;
        }
        public bool Update(User User)
        {
            return _UserRepository.update(User);
        }

        public ICollection<User> FindAll()
        {
            var Users = _UserRepository.findAll();
            return Users;
        }

        public ICollection<User> FindAll(string[] includes)
        {
            var Users = _UserRepository.findAll(includes);
            return Users;
        }

        public User FindById(int id)
        {
            return _UserRepository.findById(id);
        }

        public User Login(string username,string password)
        {
            var User = _UserRepository.Login(username,password);
            return User;
        }

        public void Save()
        {
            _unitOfWork.commit();
        }

        public User FindByUsername(string username)
        {
            return _UserRepository.findByCondition(x => x.Username == username).SingleOrDefault();
        }
    }
}

using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string username, string password);
        bool EditBillInfo(User user);
        bool ChangePass(int id, string newpassword,string password);


    }
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public User Login(string username, string password)
        {
            return DbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool EditBillInfo(User user)
        {
            var existingEntity = DbContext.Users.Find(user.ID);

            user.Password = existingEntity.Password;
            user.RoleID = existingEntity.RoleID;
            user.Status = existingEntity.Status;

            DbContext.Entry(existingEntity).CurrentValues.SetValues(user);
            return DbContext.SaveChanges()>0;
        }
        
        public bool ChangePass(int id,string newpassword, string password)
        {
            var existingEntity = DbContext.Users.Find(id);

            if (password != existingEntity.Password) return false;

            User user = new User();

            user.ID = existingEntity.ID;
            user.Username = existingEntity.Username;
            user.Password = newpassword;
            user.Name = existingEntity.Name;
            user.Address = existingEntity.Address;
            user.Mobile = existingEntity.Mobile;
            user.Email = existingEntity.Email;
            user.RoleID = existingEntity.RoleID;
            user.Status = existingEntity.Status;

        DbContext.Entry(existingEntity).CurrentValues.SetValues(user);
            return DbContext.SaveChanges()>0;
        }
    }
}

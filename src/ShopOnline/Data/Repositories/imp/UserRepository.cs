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
    }
}

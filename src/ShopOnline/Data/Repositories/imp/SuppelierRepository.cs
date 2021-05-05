using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface ISuppelierRepository : IRepository<Suppelier>
    {

    }
    public class SuppelierRepository : RepositoryBase<Suppelier>, ISuppelierRepository
    {
        public SuppelierRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}

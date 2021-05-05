using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IConfirmStatusRepository : IRepository<ConfirmStatus>
    {

    }
    public class ConfirmStatusRepository : RepositoryBase<ConfirmStatus>, IConfirmStatusRepository
    {
        public ConfirmStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}

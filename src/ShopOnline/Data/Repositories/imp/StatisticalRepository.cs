using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IStatisticalRepository : IRepository<Statistical>
    {

    }
    public class StatisticalRepository : RepositoryBase<Statistical>, IStatisticalRepository
    {
        public StatisticalRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}

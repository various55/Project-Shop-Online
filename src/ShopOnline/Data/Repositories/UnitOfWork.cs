using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ShopContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public ShopContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = _dbFactory.Init());
            }
        }

        public void commit()
        {
            DbContext.SaveChanges();
        }
    }
}

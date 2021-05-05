using Autofac.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DbFactory : Disposable, IDbFactory
    {
        // Factory dùng để khởi tạo MyDbcontext
        private ShopContext dbContext;

        public ShopContext Init()
        {
            return dbContext = (dbContext ?? new ShopContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null) dbContext.Dispose();
        }

    }
}

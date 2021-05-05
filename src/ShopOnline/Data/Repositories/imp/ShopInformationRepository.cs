using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IShopInformationRepository : IRepository<ShopInformation>
    {

    }
    public class ShopInformationRepository : RepositoryBase<ShopInformation>, IShopInformationRepository
    {
        public ShopInformationRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}

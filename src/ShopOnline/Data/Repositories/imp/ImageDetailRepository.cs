using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IImageDetailRepository : IRepository<ImageDetail>
    {

    }
    public class ImageDetailRepository : RepositoryBase<ImageDetail>, IImageDetailRepository
    {
        public ImageDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}

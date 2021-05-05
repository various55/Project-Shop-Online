using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface ITagProductRepository : IRepository<TagProduct>
    {

    }
    public class TagProductRepository : RepositoryBase<TagProduct>, ITagProductRepository
    {
        public TagProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}

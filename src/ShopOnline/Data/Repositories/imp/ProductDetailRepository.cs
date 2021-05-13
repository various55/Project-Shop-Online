using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IProductDetailRepository : IRepository<ProductDetail>
    {
        ProductDetail Find(int id, int size, int color);
    }
    public class ProductDetailRepository : RepositoryBase<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public ProductDetail Find(int id, int size, int color)
        {
            return DbContext.ProductDetails.SingleOrDefault(p => p.ProductID == id && p.SizeID == size && p.ColorID == color);
        }
    }
}

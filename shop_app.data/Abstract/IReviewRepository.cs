using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IReviewRepository: IRepositoryBase<Review>
    {
        public Task<IEnumerable<Review>> GetReviewsByProduct(Product product);
    }
}

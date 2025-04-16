using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Abstract
{
    public interface IReviewService: IServiceBase<Review>
    {
        public Task<IDataResult<IEnumerable<Review>>> GetReviewsByProduct(Product product);
    }
}

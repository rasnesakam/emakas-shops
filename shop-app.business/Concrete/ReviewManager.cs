using shop_app.data.Abstract;
using shop_app.data.Exceptions;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Concrete
{
    public class ReviewManager : ServiceBase<Review>, IReviewService
    {
        public ReviewManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IDataResult<IEnumerable<Review>>> GetReviewsByProduct(Product product)
        {
            try
            {
                IEnumerable<Review> reviews = await _unitOfWork.ReviewRepository.GetReviewsByProduct(product);
                return new DataResult<IEnumerable<Review>>(reviews);
            } catch (NoElementFoundException notFound)
            {
                return new DataResult<IEnumerable<Review>>(notFound);
            }
        }
    }
}

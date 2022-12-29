using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.ControllerExtensions;
using shop_app.contract.Requests.Queries;
using shop_app.entity;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : Controller
    {
        private IMediator mediator;

        public ReviewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{productURI}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByProduct([FromRoute] string productURI)
        {
            var productResult = await mediator.Send(new GetProductByUriRequest() { Uri = productURI});
            if (productResult.Succeed)
            {
                var reviewResult = await mediator.Send(new GetReviewsByProductRequest() { Product = productResult.Value});
                return this.FromResult(reviewResult);
            }
            return BadRequest(new { Message = "No product found with given uri"});
        }
    }
}

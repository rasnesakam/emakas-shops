using MediatR;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.Requests.Queries;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System.Collections;

namespace shop_app.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<Product>> GetProducts() // Query
        {
            var response = await _mediator.Send(new GetAllProductsQuery());
            if (response.Status == ResultStatus.Success)
            {
                return response.Payload;
            }
            else return new List<Product>();
        }

        [HttpGet("{categoryURI}")] // Query
        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryURI) // Error result, SuccessResult falan filan
        {
            var categoryResult = await _mediator.Send(new GetCategoryByURIQuery(categoryURI));
            if (categoryResult.Status == ResultStatus.Success)
            {
                var productStatus = await _mediator.Send(new GetProductsByCategoryRequest(categoryResult.Payload));
                if (productStatus.Status == ResultStatus.Success)
                {
                    return productStatus.Payload;
                }
            }
            return new List<Product>();
        }
    }
}

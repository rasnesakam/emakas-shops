using MediatR;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.Requests.Abstract;
using shop_app.api.Requests.Queries;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System.Collections;
using System.Net;

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
            throw new HttpRequestException(response.Message, response.Exception, HttpStatusCode.NotFound);

        }

        [HttpGet("{productName}")]
        public async Task<Product> GetProductByNameAsync(string name)
        {
            var response = await _mediator.Send(new GetProductsByNameQuery() { Name = name});
            if (response.Status == ResultStatus.Success)
                return response.Payload;
            throw new HttpRequestException(response.Message, response.Exception,HttpStatusCode.NotFound);
        }

        [HttpGet("{categoryURI}")]
        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryURI) // Error result, SuccessResult falan filan
        {
            var categoryResult = await _mediator.Send(new GetCategoryByURIQuery(categoryURI));
            if (categoryResult.Status == ResultStatus.Success)
            {
                var productStatus = await _mediator.Send(new GetProductsByCategoryRequest(categoryResult.Payload));
                if (productStatus.Status == ResultStatus.Success)
                    return productStatus.Payload;
                throw new HttpRequestException(productStatus.Message, productStatus.Exception, HttpStatusCode.NotFound);
            }
            throw new HttpRequestException(categoryResult.Message, categoryResult.Exception,HttpStatusCode.NotFound);
        }
    }
}

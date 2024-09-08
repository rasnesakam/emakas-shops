using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using shop_app.api.ControllerExtensions;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

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
        
        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery]int page, [FromQuery]int size) // Query
        {
            var response = await _mediator.Send(new GetAllProductsRequest {Page=page, Size=size});
            return this.FromResult(response);
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() // Query
        {
            var response = await _mediator.Send(new GetAllProductsRequest());
            return this.FromResult(response);
        }

        [HttpGet]
        [Route("Name/{productName}")]
        public async Task<ActionResult<Product>> GetProductByNameAsync(string name)
        {
            var response = await _mediator.Send(new GetProductByNameRequest { Name = name});
            return this.FromResult(response);
        }

        [HttpGet]
        [Route("{uri}")]
        public async Task<ActionResult<Product>> GetProductByUri([FromRoute] string uri)
        {
            var response = await _mediator.Send(new GetProductByUriRequest { Uri = uri });
            return this.FromResult(response);
        }
        
        
        [HttpGet]
        [Route("Search/{productName}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProductByNameAsync([FromRoute] string productName)
        {
            var response = await _mediator.Send(new SearchProductsByName() { Name = productName});
            return this.FromResult(response);
        }

        [HttpGet]
        [Route("Category/{categoryUri}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromRoute]string categoryUri) // Error result, SuccessResult falan filan
        {
            var categoryResult = await _mediator.Send(new GetCategoryByURIRequest {Uri = categoryUri});
            if (categoryResult.Succeed)
            {
                var productResult = await _mediator.Send(new GetProductsByCategoryRequest(categoryResult.Value));
                return this.FromResult(productResult);
            }
            return BadRequest(new NotFoundErrorResult<IEnumerable<Product>>("There is no such category"));
        }
        

        //TODO: Authorized Action
        [HttpPost]
        [Route("Submit")]
        public async Task<ActionResult<Product>> SubmitProduct([FromBody] ProductDto productDto)
        {
            Product product = new Product
                {
                    Name = productDto.Name,
                    Brand = productDto.Brand,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    Uri = String.Concat(productDto.Name.ToLower().Replace(" ","-"),"-",Guid.NewGuid().ToString("n").Substring(24))
                    
                };
            // Kategoriye bak
            var categoryResponse = await _mediator.Send(new GetCategoryByURIRequest { Uri = productDto.Categories[0].Uri });
            if (!categoryResponse.Succeed)
                return BadRequest("Invalid Category");
            product.Categories = new Category[] {categoryResponse.Value!};
            // Ürünü Ekle
            var productResponse = await _mediator.Send(new SubmitProductRequest()
            {
                Product = product
            });
            if (!productResponse.Succeed)
                return this.FromResult<Product>(productResponse);
            // Ürün Fotoğraflarını Ekle
            await _mediator.Send(new SubmitProductImagesRequest()
            {
                ProductId = product.Id,
                ProductImageDtos = productDto.ProductImages
            });
            // Özelliklerini Ekle
            await _mediator.Send(new SubmitPropertiesRequest
            {
                PropertyDtos = productDto.Properties,
                ProductId = product.Id
            });
            // Etiketleri Ekle
            await _mediator.Send(new SubmitProductTagsRequest()
            {
                ProductId = product.Id,
                ProductTagDtos = productDto.Tags
            });
            return this.FromResult(productResponse);
        }
    }
} 

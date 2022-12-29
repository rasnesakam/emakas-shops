using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.data.Abstract;
using shop_app.data.Exceptions;
using shop_app.entity;
using shop_app.service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Handlers
{
    public class GetProductByUriRequestHandler : IRequestHandler<GetProductByUriRequest, ServiceResult<Product>>
    {
        private readonly IProductService productService;
        public async Task<ServiceResult<Product>> Handle(GetProductByUriRequest request, CancellationToken cancellationToken)
        {
            var result = await productService.GetByUri(uri: request.Uri);
            if (result.Status == shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                return new ServiceResult<Product>(result.Payload);
            if (result.Exception is NoElementFoundException)
                return new NotFoundErrorResult<Product>();
            return new InternalServerErrorResult<Product>()
        }
    }
}

using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Handlers
{

    public class SubmitProductCategoryHandler : IRequestHandler<SubmitProductCategoryRequest, ServiceResult<ProductCategory>>
    {
        private IProductCategoryService _service;

        public SubmitProductCategoryHandler(IProductCategoryService service)
        {
            _service = service;
        }

        public async Task<ServiceResult<ProductCategory>> Handle(SubmitProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _service.Create(request.ProductCategory);
            return response.Status switch 
            {
                ResultStatus.Success => new SuccessStatus<ProductCategory>(request.ProductCategory),
                _=> new InternalServerErrorResult<ProductCategory>(response.Message,response.Exception)
            };
        }
    }
}

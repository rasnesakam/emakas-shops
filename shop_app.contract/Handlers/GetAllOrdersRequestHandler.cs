using MediatR;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Handlers
{
    public class GetAllOrdersRequestHandler : IRequestHandler<GetAllOrdersRequest, ServiceResult<IEnumerable<Order>>>
    {
        private readonly IOrderService _service;

        public GetAllOrdersRequestHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<ServiceResult<IEnumerable<Order>>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAll();
            if (result.Status == shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                return new SuccessStatus<IEnumerable<Order>>(result.Payload);

            return new NotFoundErrorResult<IEnumerable<Order>>();
        }
    }
}

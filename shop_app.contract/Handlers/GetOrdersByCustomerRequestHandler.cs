using MediatR;
using shop_app.contract.Requests.Queries;
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
    public class GetOrdersByCustomerRequestHandler : IRequestHandler<GetOrdersByCustomerReqest, ServiceResult<IEnumerable<Order>>>
    {
        private readonly IOrderService _orderService;

        public GetOrdersByCustomerRequestHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ServiceResult<IEnumerable<Order>>> Handle(GetOrdersByCustomerReqest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllByCustomerId(request.UserId);
            if (result.Status == ResultStatus.Success)
                return new SuccessStatus<IEnumerable<Order>>(result.Payload);
            return new NotFoundErrorResult<IEnumerable<Order>>();
        }
    }
}

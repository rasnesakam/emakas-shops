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
    internal class GetOrdersBySellerRequestHandler : IRequestHandler<GetOrdersBySellerRequest, ServiceResult<IEnumerable<Order>>>
    {
        private readonly IOrderService _orderService;

        public GetOrdersBySellerRequestHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        

        public async Task<ServiceResult<IEnumerable<Order>>> Handle(GetOrdersBySellerRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllByCustomerId(request.SellerId);
            if (result.Status == ResultStatus.Success)
                return new SuccessStatus<IEnumerable<Order>>(result.Payload);
            return new NotFoundErrorResult<IEnumerable<Order>>();
        }
    }
}

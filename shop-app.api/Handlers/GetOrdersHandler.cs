using MediatR;
using shop_app.api.Requests.Queries;
using shop_app.data.Abstract;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IDataResult<IEnumerable<Order>>>
    {
        private readonly IOrderService _orderService;

        public GetOrdersHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IDataResult<IEnumerable<Order>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllByUserId(request.UserId);
        }
    }
}

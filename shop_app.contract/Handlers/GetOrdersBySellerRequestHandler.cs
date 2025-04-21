using AutoMapper;
using MediatR;
using shop_app.contract.dto;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers
{
    internal class GetOrdersBySellerRequestHandler : IRequestHandler<GetOrdersBySellerRequest, ServiceResult<IEnumerable<OrderDto>>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public GetOrdersBySellerRequestHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        

        public async Task<ServiceResult<IEnumerable<OrderDto>>> Handle(GetOrdersBySellerRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllByCustomerId(request.SellerId);
            if (result.Status == ResultStatus.Success)
                return new SuccessStatus<IEnumerable<OrderDto>>(result.Payload.Select(o => _mapper.Map<OrderDto>(o)));
            return new NotFoundErrorResult<IEnumerable<OrderDto>>();
        }
    }
}

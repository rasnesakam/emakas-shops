using MediatR;
using shop_app.api.Requests.Commands;
using shop_app.service.Abstract;
using IResult =  shop_app.shared.Utilities.Results.Abstract.IResult;

namespace shop_app.api.Handlers
{
    public class SubmitOrderCommandHandler : IRequestHandler<SubmitOrderCommand, IResult>
    {
        private readonly IOrderService _orderService;

        public SubmitOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IResult> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderService.Create(new entity.Order()
            {
                UserId = request.UserId,
                Product = request.Product,
                Note = request.Note,
            });
        }
    }
}

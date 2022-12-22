using MediatR;
using shop_app.contract.Requests.Commands;
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
    public class SubmitOrderHandler : IRequestHandler<SubmitOrderRequest, ServiceResult<Order>>
    {
        private readonly IOrderService _service;
        private readonly IMediator _mediator;

        public SubmitOrderHandler(IOrderService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        public async Task<ServiceResult<Order>> Handle(SubmitOrderRequest request, CancellationToken cancellationToken)
        {
            // TODO: Add address correction
            var result = await _service.Create(request.Order);
            if (result.Status == shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                return new SuccessStatus<Order>(request.Order);
            return new InternalServerErrorResult<Order>(result.Message);
        }
    }
}

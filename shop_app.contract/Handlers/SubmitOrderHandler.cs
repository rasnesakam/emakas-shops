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
using AutoMapper;
using shop_app.contract.dto;
using shop_app.contract.Dto;

namespace shop_app.contract.Handlers
{
    public class SubmitOrderHandler : IRequestHandler<SubmitOrderRequest, ServiceResult<OrderDto>>
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubmitOrderHandler(IOrderService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ServiceResult<OrderDto>> Handle(SubmitOrderRequest request, CancellationToken cancellationToken)
        {
            // TODO: Add address correction
            var result = await _service.Create(_mapper.Map<Order>(request.Order));
            if (result.Status == shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
            {
                if (request.Order.Address.Id.HasValue && request.Order.Address.SaveAddress)
                    _mediator.Send(new SaveAddressRequest { Address = request.Order.Address });
                return new SuccessStatus<OrderDto>(request.Order);
            }
            return new InternalServerErrorResult<OrderDto>(result.Message);
        }
    }
}

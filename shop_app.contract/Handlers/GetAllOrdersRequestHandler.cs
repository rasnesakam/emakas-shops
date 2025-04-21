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
using AutoMapper;
using shop_app.contract.dto;

namespace shop_app.contract.Handlers
{
    public class GetAllOrdersRequestHandler : IRequestHandler<GetAllOrdersRequest, ServiceResult<IEnumerable<OrderDto>>>
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public GetAllOrdersRequestHandler(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<OrderDto>>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAll();
            if (result.Status == shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                return new SuccessStatus<IEnumerable<OrderDto>>(result.Payload.Select(o => _mapper.Map<OrderDto>(o)));

            return new NotFoundErrorResult<IEnumerable<OrderDto>>();
        }
    }
}

using AutoMapper;
using MediatR;
using shop_app.contract.Dto;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SaveCustomerHandler: IRequestHandler<SaveCustomerRequest, ServiceResult<CustomerDto>>
{
    private readonly ICustomerService _service;
    private readonly IMapper _mapper;

    public SaveCustomerHandler(ICustomerService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CustomerDto>> Handle(SaveCustomerRequest request, CancellationToken cancellationToken)
    {
        Customer customer = _mapper.Map<Customer>(request.Customer);
        IResult result = await _service.Create(customer);
        return result.Status switch
        {
            ResultStatus.Success => new SuccessStatus<CustomerDto>(_mapper.Map<CustomerDto>(customer)),
            ResultStatus.BadArgument => new BadRequestErrorResult<CustomerDto>(result.Message),
            _ => new InternalServerErrorResult<CustomerDto>(result.Message)
        };
    }
}
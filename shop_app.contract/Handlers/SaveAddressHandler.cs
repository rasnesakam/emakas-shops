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

public class SaveAddressHandler: IRequestHandler<SaveAddressRequest, ServiceResult<AddressDto>>
{
    private readonly IAddressService _service;
    private readonly IMapper _mapper;

    public SaveAddressHandler(IAddressService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<AddressDto>> Handle(SaveAddressRequest request, CancellationToken cancellationToken)
    {
        IResult result;
        Address address = _mapper.Map<Address>(request.Address);
        if (request.Address.Id.HasValue)
            result = await _service.Update(address);
        else
            result = await _service.Create(address);
        return result.Status switch
        {
            ResultStatus.Success => new SuccessStatus<AddressDto>(_mapper.Map<AddressDto>(address)),
            ResultStatus.NotFound => new NotFoundErrorResult<AddressDto>(),
            ResultStatus.BadArgument => new BadRequestErrorResult<AddressDto>(result.Message),
            _ => new InternalServerErrorResult<AddressDto>(result.Message)
        };
    }
}
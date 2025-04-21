using System.Collections;
using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductImagesHandler: IRequestHandler<SubmitProductImagesRequest, ServiceResult<IEnumerable<ProductImageDto>>>
{
    private readonly IProductImageService _service;
    private readonly IMapper _mapper;

    public SubmitProductImagesHandler(IProductImageService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<ProductImageDto>>> Handle(SubmitProductImagesRequest request, CancellationToken cancellationToken)
    {
        var productImages = request.ProductImageDtos.Select(images => new ProductImage()
        {
            ProductId = request.ProductId,
            FileUri = images.FileUri,
            AltText = images.AltText
        }).ToList();

        var response = await _service.CreateBatch(productImages, cancellationToken);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<ProductImageDto>>(productImages.Select(pi => _mapper.Map<ProductImageDto>(pi))),
            _ => new InternalServerErrorResult<IEnumerable<ProductImageDto>>(response.Message, response.Exception)
        };
    }
}
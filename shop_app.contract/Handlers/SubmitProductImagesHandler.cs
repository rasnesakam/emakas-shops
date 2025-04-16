using System.Collections;
using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductImagesHandler: IRequestHandler<SubmitProductImagesRequest, ServiceResult<IEnumerable<ProductImage>>>
{
    private readonly IProductImageService _service;

    public SubmitProductImagesHandler(IProductImageService service)
    {
        _service = service;
    }

    public async Task<ServiceResult<IEnumerable<ProductImage>>> Handle(SubmitProductImagesRequest request, CancellationToken cancellationToken)
    {
        var productImages = request.ProductImageDtos.Select(images => new ProductImage()
        {
            ProductId = request.ProductId,
            FileUri = images.FileUri,
            AltText = images.AltText
        });
        var response = await _service.CreateBatch(productImages, cancellationToken);
        return response.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<ProductImage>>(productImages),
            _ => new InternalServerErrorResult<IEnumerable<ProductImage>>(response.Message, response.Exception)
        };
    }
}
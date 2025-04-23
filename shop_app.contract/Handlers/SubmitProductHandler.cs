using System.Collections;
using AutoMapper;
using MediatR;
using shop_app.contract.DTO;
using shop_app.contract.Requests.Commands;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class SubmitProductHandler: IRequestHandler<SubmitProductRequest, ServiceResult<ProductDto>>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SubmitProductHandler(IProductService service, IMapper mapper, IMediator mediator)
    {
        _service = service;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ServiceResult<ProductDto>> Handle(SubmitProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Product.Name,
            Brand = request.Product.Brand,
            Description = request.Product.Description,
            Price = request.Product.Price,
            Uri = string.Concat(request.Product.Name.ToLower().Replace(" ","-"),"-",Guid.NewGuid().ToString("n").Substring(24))
                    
        };
        // Kategoriye bak
        var categoryResponse = await _mediator.Send(new GetCategoryByURIRequest { Uri = request.Product.Categories[0].Uri }, cancellationToken);
        if (!categoryResponse.Succeed)
            return new BadRequestErrorResult<ProductDto>("Invalid Category");
        product.Categories = new Category[] {_mapper.Map<Category>(categoryResponse.Value!)};
        // Ürünü Ekle
        var response = await _service.Create(_mapper.Map<Product>(product));

        if (response.Status == ResultStatus.Success)
        {
            // Ürün Fotoğraflarını Ekle
            product.ProductImages =
                await AttachProductImages(product.Id, request.Product.ProductImages, cancellationToken);
            // Özelliklerini Ekle
            product.Properties =
                await AttachProductProperties(product.Id, request.Product.Properties!, cancellationToken);
            // Etiketleri Ekle
            product.Tags = await AttachProductTags(product.Id, request.Product.Tags!, cancellationToken);
            return new SuccessStatus<ProductDto>(_mapper.Map<ProductDto>(product));
        }
        return new InternalServerErrorResult<ProductDto>(response.Message, response.Exception);
        
    }

    private async Task<IEnumerable<ProductImage>> AttachProductImages(Guid productId, 
        IEnumerable<ProductImageDto> productImageDtos, CancellationToken cancellationToken)
    {
        var imagesResult = await _mediator.Send(new SubmitProductImagesRequest()
        {
            ProductId = productId,
            ProductImageDtos = productImageDtos
        }, cancellationToken);
        return imagesResult.Succeed ? 
            imagesResult.Value!.Select(pi => _mapper.Map<ProductImage>(pi)).ToList()
            : new List<ProductImage>();
    }

    private async Task<IEnumerable<Property>> AttachProductProperties(Guid productId,
        IEnumerable<PropertyDto> propertyDtos, CancellationToken cancellationToken)
    {
        var propsResult = await _mediator.Send(new SubmitPropertiesRequest()
        {
            ProductId = productId,
            PropertyDtos = propertyDtos
        }, cancellationToken);
        return propsResult.Succeed ? 
            propsResult.Value!.Select(pi => _mapper.Map<Property>(pi)).ToList()
            : new List<Property>();
    }
    private async Task<IEnumerable<ProductTag>> AttachProductTags(Guid productId,
        IEnumerable<ProductTagDto> productTagDtos, CancellationToken cancellationToken)
    {
        var tagsResult = await _mediator.Send(new SubmitProductTagsRequest()
        {
            ProductId = productId,
            ProductTagDtos = productTagDtos
        }, cancellationToken);
        return tagsResult.Succeed ? 
            tagsResult.Value!.Select(pt => _mapper.Map<ProductTag>(pt)).ToList()
            : new List<ProductTag>();
    }
}
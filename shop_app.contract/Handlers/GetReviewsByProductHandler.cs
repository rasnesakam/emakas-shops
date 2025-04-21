using AutoMapper;
using MediatR;
using shop_app.contract.Dto;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;

namespace shop_app.contract.Handlers;

public class GetReviewsByProductHandler: IRequestHandler<GetReviewsByProductRequest, ServiceResult<IEnumerable<ReviewDto>>>
{
    private readonly IReviewService _service;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetReviewsByProductHandler(IReviewService service, IMapper mapper, IMediator mediator)
    {
        _service = service;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ServiceResult<IEnumerable<ReviewDto>>> Handle(GetReviewsByProductRequest request, CancellationToken cancellationToken)
    {
        var productResult = 
            await _mediator.Send(new GetProductByUriRequest { Uri = request.ProductUri }, cancellationToken);
        if (!productResult.Succeed)
            return new NotFoundErrorResult<IEnumerable<ReviewDto>>(productResult.Exception?.Message);
        var product = _mapper.Map<Product>(productResult.Value);
        var reviewsResult = await _service.GetReviewsByProduct(product);
        return reviewsResult.Status switch
        {
            ResultStatus.Success => new SuccessStatus<IEnumerable<ReviewDto>>(
                reviewsResult.Payload.Select(r => _mapper.Map<ReviewDto>(r))),
            ResultStatus.NotFound => new NotFoundErrorResult<IEnumerable<ReviewDto>>(),
            _ => new InternalServerErrorResult<IEnumerable<ReviewDto>>(reviewsResult.Message)
        };
    }
}
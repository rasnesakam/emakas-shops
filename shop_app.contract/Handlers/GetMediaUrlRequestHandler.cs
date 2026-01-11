using MediatR;
using Microsoft.Extensions.Logging;
using shop_app.contract.Requests.Queries;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.service.Exceptions;

namespace shop_app.contract.Handlers;

public class GetMediaUrlRequestHandler: IRequestHandler<GetMediaUrlRequest, ServiceResult<string>>
{
    private readonly IMediaService _mediaService;
    private readonly ILogger _logger;

    public GetMediaUrlRequestHandler(IMediaService mediaService, ILogger logger)
    {
        _mediaService = mediaService;
        _logger = logger;
    }

    public async Task<ServiceResult<string>> Handle(GetMediaUrlRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _mediaService.GetPresignedGetUrl(request.ObjectKey);
            return new SuccessStatus<string>(result);
        }
        catch (NotFoundException exception)
        {
            _logger.LogError(exception.StackTrace);
            return new NotFoundErrorResult<string>(exception.Message);
        }
        catch (ArgumentException exception)
        {
            _logger.LogError(exception.StackTrace);
            return new BadRequestErrorResult<string>(exception.Message);
        }
    }
}
using MediatR;
using shop_app.contract.Requests.Commands;
using shop_app.contract.ServiceResults;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using shop_app.shared.Utilities.Results.Concrete;

namespace shop_app.contract.Handlers;

public class UploadFileRequestHandler: IRequestHandler<UploadFileRequest, ServiceResult<String>>
{
    private readonly IMediaService _mediaService;

    public UploadFileRequestHandler(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    public async Task<ServiceResult<string>> Handle(UploadFileRequest request, CancellationToken cancellationToken)
    {
        switch (request.Size)
        {
            // İş kuralları
            case <= 0:
                return new BadRequestErrorResult<string>("File is empty");
            // 10 MB limiti
            case > 10 * 1024 * 1024:
                return new BadRequestErrorResult<string>("File is too big");
        }
        var allowedTypes = new[] { "image/jpeg", "image/png", "application/pdf" };
        if (!allowedTypes.Contains(request.ContentType))
            return new BadRequestErrorResult<string>("Invalid file format.");
        var objectName = await _mediaService.UploadFile(request.FileName, request.ContentType, request.Stream);
        return new SuccessStatus<string>(objectName);
    }
}
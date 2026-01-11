using MediatR;
using shop_app.contract.ServiceResults;

namespace shop_app.contract.Requests.Commands;

public class UploadFileRequest: IRequest<ServiceResult<string>>
{
    public string FileName { get; set; }
    public long Size { get; set; }
    public string ContentType { get; set; }
    public Stream Stream { get; set; }
}
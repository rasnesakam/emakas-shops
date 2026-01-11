using Microsoft.Extensions.Configuration;
using Minio;

namespace shop_app.service.Abstract;

public interface IMediaService
{
    public Task<string> GetPresignedGetUrl(string objectName);
    public Task<string> UploadFile(string fileName, string contentType, Stream fileData);
}
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using shop_app.service.Abstract;
using shop_app.service.Exceptions;

namespace shop_app.service.Concrete;

public class MediaService: IMediaService
{
    private readonly IMinioClient _minioClient;
    private readonly IConfiguration _configuration;
    private readonly string _bucket;
    
    public MediaService(IMinioClient minioClient, IConfiguration configuration)
    {
        _minioClient = minioClient;
        _configuration = configuration;
        _bucket = _configuration["Minio:BucketName"];
        
    }

    public async Task<string> GetPresignedGetUrl(string objectName)
    {
        var expiry = 3600; // One hour
        var presignedArgs = new PresignedGetObjectArgs()
            .WithBucket(_bucket)
            .WithObject(objectName)
            .WithExpiry(expiry);
        try
        {
            return await _minioClient.PresignedGetObjectAsync(presignedArgs);
        }
        catch (InvalidObjectNameException exception)
        {
            throw new ArgumentException(exception.Message, exception);
        }
        catch (ObjectNotFoundException exception)
        {
            throw new NotFoundException(exception.Message, exception);
        }
    }

    public async Task<string> UploadFile(string fileName, string contentType, Stream fileData)
    {
        bool exists = await _minioClient.BucketExistsAsync(new BucketExistsArgs()
            .WithBucket(_bucket));

        if (!exists)
        {
            await _minioClient.MakeBucketAsync(new MakeBucketArgs()
                .WithBucket(_bucket));
        }

        var response = await _minioClient.PutObjectAsync(
            new PutObjectArgs()
                .WithBucket(_bucket)
                .WithObject(fileName)
                .WithStreamData(fileData)
                .WithObjectSize(fileData.Length)
                .WithContentType(contentType)
        );
        return response.ObjectName;
    }
}
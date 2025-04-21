using AutoMapper;
using shop_app.contract.DTO;
using shop_app.entity;

namespace shop_app.contract.DtoProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // ProductDto -> Product
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id genellikle veritabanı tarafından oluşturulur
            .ForMember(dest => dest.Uri, opt => opt.MapFrom(src => GenerateUri(src.Name))) // Özel URI oluşturma
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow)) // Oluşturulma zamanı
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => Status.PUBLISHED)) // Varsayılan bir statü atayabilirsiniz
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages.ToList()))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.ToList()))
            .ForMember(dest => dest.Properties,
                opt => opt.MapFrom(src => src.Properties != null ? src.Properties.ToList() : null))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.ToList()))
            .ForMember(dest => dest.Reviews, opt => opt.Ignore()); // Review'lar genellikle ayrı bir işlemle eklenir

        // Product -> ProductDto
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages.ToArray()))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.ToArray()))
            .ForMember(dest => dest.Properties,
                opt => opt.MapFrom(src => src.Properties != null ? src.Properties.ToArray() : null))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.ToArray()));
    }

    // Özel URI oluşturma metodu (örnek)
    private string GenerateUri(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        string lowercasedName = name.ToLowerInvariant().Replace(' ', '-');
        string lastPartOfGuid =
            Guid.NewGuid().ToString().Split('-').LastOrDefault()?.ToLowerInvariant() ?? string.Empty;
        return $"{lowercasedName}-{lastPartOfGuid}";
    }
}
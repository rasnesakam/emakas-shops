
using shop_app.entity;

namespace shop_app.contract.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryDto[] Categories { get; set; }
        public ProductImageDto[] ProductImages { get; set; }
        public PropertyDto[]? Properties { get; set; }
        public ProductTagDto[] Tags { get; set; }
    }
}


using shop_app.entity;

namespace shop_app.contract.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SellerId { get; set; }
        public Category[] Categories { get; set; }
        public string[] Tags { get; set; }
    }
}

using shop_app.contract.Dto;
using shop_app.contract.DTO;

namespace shop_app.contract.dto
{
    public class OrderDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public CustomerDto Customer { get; set; }
        public AddressDto Address { get; set; }
        public string OrderNote { get; set; }
        public string SellerNote { get; set; }
    }
}

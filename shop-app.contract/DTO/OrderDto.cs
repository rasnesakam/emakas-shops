namespace shop_app.contract.dto
{
    public class OrderDto
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public string OrderNote { get; set; }
        public string SellerNote { get; set; }
    }
}

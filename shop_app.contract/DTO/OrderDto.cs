namespace shop_app.api.Models
{
    public class OrderDto
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public string Note { get; set; }

    }
}

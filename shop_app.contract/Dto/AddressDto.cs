namespace shop_app.contract.Dto;

public class AddressDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string AddressType { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public CustomerDto Customer { get; set; }
    public bool SaveAddress { get; set; }
}
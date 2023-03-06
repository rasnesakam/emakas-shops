using System;

namespace shop_app.entity;

public class ProductImage
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string FileUri { get; set; }
    public string AltText { get; set; }
}
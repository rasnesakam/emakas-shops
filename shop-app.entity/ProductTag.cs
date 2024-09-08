using System;

namespace shop_app.entity;

public class ProductTag
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Tag { get; set; }
}
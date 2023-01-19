using System;

namespace shop_app.entity;

public class NonMemberOrder: Order
{
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string CustomerMiddleName { get; set; }
    public string CustomerMail { get; set; }
    public string CustomerPhone { get; set; }
}
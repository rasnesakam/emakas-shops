using FluentValidation;
using shop_app.contract.dto;


namespace shop_app.api.DataValidators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(dto => dto.SellerId).NotEmpty();
            RuleFor(dto => dto.ProductId).NotEmpty();
            RuleFor(dto => dto.AddressId);
            RuleFor(dto => dto.OrderNote).MaximumLength(140);
        }
    }
}

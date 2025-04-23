using FluentValidation;
using shop_app.contract.dto;


namespace shop_app.api.DataValidators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(dto => dto.Products).NotEmpty();
            RuleFor(dto => dto.Address).NotEmpty();
            RuleFor(dto => dto.OrderNote).MaximumLength(140);
        }
    }
}

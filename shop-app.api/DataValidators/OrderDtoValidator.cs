using FluentValidation;
using shop_app.api.Models;

namespace shop_app.api.DataValidators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(dto => dto.UserId).NotEmpty();
            RuleFor(dto => dto.ProductId).NotEmpty();
            RuleFor(dto => dto.Note).MaximumLength(140);
        }
    }
}

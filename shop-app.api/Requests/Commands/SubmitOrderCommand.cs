using MediatR;
using shop_app.entity;
using IResult = shop_app.shared.Utilities.Results.Abstract.IResult;

namespace shop_app.api.Requests.Commands
{
    public class SubmitOrderCommand: IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public Product Product { get; set; }
        public string Note { get; set; }
    }
}

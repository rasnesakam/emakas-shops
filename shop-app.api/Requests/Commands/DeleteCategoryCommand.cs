using MediatR;
using IResult = shop_app.shared.Utilities.Results.Abstract.IResult; 

namespace shop_app.api.Requests.Commands
{
    public class DeleteCategoryCommand: IRequest<IResult>
    {
        string URI { get; set; }
    }
}

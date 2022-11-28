using MediatR;
using shop_app.entity;
using shop_app.shared.Utilities.Results.Abstract;

namespace shop_app.api.Requests.Queries
{
    public class GetCategoryByURIQuery: IRequest<IDataResult<Category>>
    {
        public string URI { get; set; }

        public GetCategoryByURIQuery(string uRI)
        {
            URI = uRI;
        }
    }
}

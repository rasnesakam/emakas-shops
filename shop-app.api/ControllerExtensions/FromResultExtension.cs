using Microsoft.AspNetCore.Mvc;
using shop_app.contract.ServiceResults;

namespace shop_app.api.ControllerExtensions
{
    public static class FromResultExtension
    {
        public static ActionResult<T> FromResult<T>(this ControllerBase controller, ServiceResult<T> result)
        {
            if (result.Exception != null)
                throw result.Exception;
            return controller.Ok(result.Value);
        }
    }
}

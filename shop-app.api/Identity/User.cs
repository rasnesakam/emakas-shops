using Microsoft.AspNetCore.Identity;

namespace shop_app.api.Identity
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

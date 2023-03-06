using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Seller : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccessKey { get; set; }
        public IEnumerable<Account>? Accounts {get;set;}
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

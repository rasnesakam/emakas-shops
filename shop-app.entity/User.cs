using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

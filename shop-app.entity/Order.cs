using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Order
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }
    }
}

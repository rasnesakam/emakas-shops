using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Requests.Queries
{
    public class GetProductRequest
    {
        public Guid ProductId { get; set; }
    }
}

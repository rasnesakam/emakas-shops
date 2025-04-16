using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public double Rate { get; set; }
    }
}

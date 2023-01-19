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

        public Address Address { get; set; }
        public Guid AddressId { get; set; }

        public IEnumerable<ProductOrder> Products { get; set; }

        public Guid CustomerId { get; set; }

		public Customer Customer { get; set; }

		public Guid SellerId { get; set; }

		public Seller Seller { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public string CustomerNote { get; set; }
        public string SellerNote { get; set; }

        public string Status { get; set; }
    }
}

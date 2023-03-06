using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Product
    {
        public Guid Id {get;set;}

		public string Name {get;set;}

		public string Description {get;set;}

		public IEnumerable<ProductImage> ProductImages { get; set; }

		public string Uri { get; set; } //[lowercased-dashed-name]-[product-id-last-part]

		public decimal Price {get;set;}

		public DateTime Created {get;set;}

		public Guid SellerId { get; set; }
		public Seller Seller { get; set; }

		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Property> Properties { get; set; }
		public IEnumerable<Review> Reviews { get; set; }
    }
}

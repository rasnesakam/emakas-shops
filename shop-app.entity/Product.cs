using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Product
    {
        public Guid Id {get;set;}

		public string Name {get;set;}

		public string Description {get;set;}

		public string ImageUrl {get;set;}

		public string Uri {get;set;} //[lowercased-dashed-name]-[product-id]

		public decimal Price {get;set;}

		public DateTime Created {get;set;}

		public Guid SellerId { get; set; }
		public User Seller { get; set; }

		public List<ProductCategory> ProductCategories {get;set;}
		public List<Property> Properties {get;set;}
    }
}

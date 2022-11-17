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

		public decimal Price {get;set;}

		public DateTime Created {get;set;}

		public List<ProductCategory> ProductCategories {get;set;}
    }
}
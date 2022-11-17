using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Category
    {
        public Guid Id {get;set;}

		public string Name {get;set;}

        public string URL {get;set;}
		public List<ProductCategory> ProductCategories { get; set; }
    }
}
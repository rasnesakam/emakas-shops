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

        public string URI {get;set;}
		public List<ProductCategory>? ProductCategories { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Category category &&
                   Name == category.Name;
        }
    }
}
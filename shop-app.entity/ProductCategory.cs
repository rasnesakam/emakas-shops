using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class ProductCategory
    {
        public Guid Id { get; set; }

		public Guid ProductId { get; set; }

		public Product Product {get;set;}

		public Guid CategoryId { get; set; }

		public Category Category {get;set;}
    }
}
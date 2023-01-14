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

		public string ImageUrl {get;set;}

		public string Uri
		{
			get
			{
				Regex pattern = new Regex("[Ç|ç|Ğ|ğ|İ|ı|Ö|ö|Ş|ş|Ü|ü|A-Z| ]");
				var replaced = pattern.Replace(Name, m =>
				{
					if (m.Value == "Ç" || m.Value == "ç")
						return "c";
					if (m.Value == "Ğ" || m.Value == "ğ")
						return "g";
					if (m.Value == "İ" || m.Value == "ı")
						return "i";
					if (m.Value == "Ö" || m.Value == "ö")
						return "o";
					if (m.Value == "Ş" || m.Value == "ş")
						return "s";
					if (m.Value.Equals("Ü") || m.Value.Equals("ü"))
						return "u";
					if (m.Value == " ")
						return "-";
					return m.Value.ToLower();
				});
				return replaced + Id.ToString().Split('-')[-1];
			}
		} //[lowercased-dashed-name]-[product-id]

		public decimal Price {get;set;}

		public DateTime Created {get;set;}

		public Guid SellerId { get; set; }
		public Seller Seller { get; set; }

		public IEnumerable<ProductCategory> ProductCategories { get; set; }
		public IEnumerable<Property> Properties { get; set; }
		public IEnumerable<Review> Reviews { get; set; }
    }
}

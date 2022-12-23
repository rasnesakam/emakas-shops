using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Property
	{
        public Guid Id {get;set;}

		public Guid ProductId {get;set;}

		public string Key {get;set;}

		public string Value {get;set;}


    }
}

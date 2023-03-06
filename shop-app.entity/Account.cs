using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.entity
{
    public class Account
    {
        public Guid Id { get; set; }
        public Guid SellerId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurName { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
    }
}

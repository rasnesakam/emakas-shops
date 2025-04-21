using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop_app.entity;

namespace shop_app.contract.DTO
{
    public class CategoryDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public Status Status { get; set; }
    }
}

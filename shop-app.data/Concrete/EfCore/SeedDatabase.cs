using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_app.entity;

namespace shop_app.data.Concrete.EfCore
{

    public static class SeedDatabase
    {

        private static Category[] Categories = {
            new Category() {Name = "Telefon",URL = "telefon"},
            new Category(){Name = "Bilgisayar", URL = "bilgisayar"}
        };
        private static Product[] Products= {
            new Product() {Name = "Telefon", Price=100.00M},
            new Product(){Name = "Bilgisayar", Price=100.00M}
        };

        public static void Seed()
        {
            /*
            var context = new ShopContext();
            
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                    context.Categories.AddRange(Categories);
                if (context.Products.Count() == 0)
                    context.Products.AddRange(Products);
                context.SaveChanges();
            }
            */

        }
    }
}

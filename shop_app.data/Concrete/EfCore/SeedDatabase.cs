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

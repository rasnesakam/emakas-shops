using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.console.Extensions
{
    public static class ExtensionClass
    {
        public static void Print(this DataClass data)
        {
            Console.WriteLine(data.Name);
            Console.WriteLine(data.Description);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();

            var result = String.Empty;

            //result = ImportUsers(db, );

        }

        //public static string ImportUsers(ProductShopContext context, string inputJson)
        //{

        //    return $"Successfully imported {users.Count}";
        //}
    }
}
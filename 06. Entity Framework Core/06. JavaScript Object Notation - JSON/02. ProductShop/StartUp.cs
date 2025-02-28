using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Reflection.Metadata;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();

            // 01. Import Users
            //string userTextJsonFile = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(db, userTextJsonFile));

            // 02. Import Products
            //string productsTextJsonFile = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(db, productsTextJsonFile));

            // 03. Import Categories
            string categoriesTextJsonFile = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(db, categoriesTextJsonFile));

        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
    }
}
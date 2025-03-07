using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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
            //string categoriesTextJsonFile = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(db, categoriesTextJsonFile));

            // 04. Import Categories and Products
            //string categoryProductsTextJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(db, categoryProductsTextJson));

            // Export Data
            // 05. Export Products in Range
            //Console.WriteLine(GetProductsInRange(db));

            // 06. Export Sold Products
            //Console.WriteLine(GetSoldProducts(db));

            // 07. Export Categories by Products Count
            Console.WriteLine(GetCategoriesByProductsCount(db));


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

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Export Data

        // 05. Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .AsNoTracking()
                .Where(x => x.Price >= 500 && x.Price <=1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductDto{ 
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}" })
                .ToArray();

            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            var productsJson = JsonConvert.SerializeObject(products, jsonSettings);

            return productsJson;
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProductsUsers = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != 0))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(x => new
                    {
                        Name = x.Name,
                        Price = x.Price,
                        buyerFirstName = x.Buyer.FirstName,
                        buyerLastName = x.Buyer.LastName,
                    })
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            var usersJson = JsonConvert.SerializeObject(soldProductsUsers, jsonSettings);

            return usersJson;
        }

        // 07. Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesProductsCount = context.Categories
                .Select(x => new ExportCategoriesProductsCountDto()
                {
                    Category = x.Name,
                    ProductCount = x.CategoriesProducts.Count,
                    AveragePrice = decimal.Round(x.CategoriesProducts.Average(cp => cp.Product.Price), 2),
                    TotalRevenue = decimal.Round(x.CategoriesProducts.Sum(cp => cp.Product.Price), 2),
                })
                .OrderByDescending(x => x.ProductCount);

            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            var categoriesProductsJson = JsonConvert.SerializeObject(categoriesProductsCount, jsonSettings);

            return categoriesProductsJson;
        }

    }
}
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static object ImportUsersDto { get; private set; }

        public static void Main()
        {
            var db = new ProductShopContext();
            string importFile;

            // 01. Import Users
            //importFile = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(db, importFile));

            // 02. Import Products
            //importFile = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(db, importFile));

            // 3. Import Categories
            //importFile = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(db, importFile));

            // 04. Import Categories and Products
            //importFile = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(db, importFile));

            // 05. Export Products In Range
            //Console.WriteLine(GetProductsInRange(db));

            // 06. Export Sold Products
            Console.WriteLine(GetSoldProducts(db));

        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]),new XmlRootAttribute("Users"));

            using var reader = new StringReader(inputXml);
            ImportUserDto[] userDtos = (ImportUserDto[])xmlSerializer.Deserialize(reader);

            ICollection<User> users = userDtos.Select(x => new User()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            }).ToList();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            using var reader = new StringReader(inputXml);
            ImportProductDto[] importProductDtos = (ImportProductDto[])xmlSerializer.Deserialize(reader);

            ICollection<Product> products = importProductDtos
                .Where(x => x.BuyerId > 0 && x.SellerId > 0)
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId
                }).ToList();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            using var reader = new StringReader(inputXml);
            ImportCategoryDto[] importCategoryDto = (ImportCategoryDto[])xmlSerializer.Deserialize(reader);

            ICollection<Category> categories = importCategoryDto
                .Where(x => x.Name != null)
                .Select(x => new Category()
                {
                    Name = x.Name
                }).ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("CategoryProducts"));

            using var reader = new StringReader(inputXml);
            ImportCategoryProductDto[] categoryProductDtos = (ImportCategoryProductDto[])xmlSerializer.Deserialize(reader);

            var categoryIds = context.Categories.AsNoTracking().Select(x => x.Id).ToArray();
            var productIds = context.Products.AsNoTracking().Select(x => x.Id).ToArray();

            ICollection<CategoryProduct> categoryProducts = categoryProductDtos
                .Where(x => categoryIds.Contains(x.CategoryId) && productIds.Contains(x.ProductId))
                .Select(x => new CategoryProduct()
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                }).ToList();

            context.AddRange();
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductDto[] products = context.Products
                .AsNoTracking()
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ExportProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = $"{x.Buyer.FirstName } {x.Buyer.LastName}",
                }).ToArray();
            
            string xmlRootAttribute = "Products";

            return ExportXml(products, xmlRootAttribute);

        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserDto[] userDtos = context.Users
                .Where(x => x.ProductsSold.Where(x=> x.BuyerId != null).Count() > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(x => new ExportUserDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldedProducts = x.ProductsSold
                        .OrderBy(o => o.Price)
                        .Select(s => new SoldProductDto()
                        {
                            Name = s.Name,
                            Price = s.Price,
                        }).ToArray()
                }).ToArray();
            string xmlRootAttribute = "Users";
            return ExportXml(userDtos, xmlRootAttribute);
        }

        // Exort to XML
        public static string ExportXml<T>(T dtoArray, string xmlRootAttribute, bool ommitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = ommitDeclaration,
                Indent = true
            };

            StringBuilder sb = new StringBuilder();

            using XmlWriter xmlWriter = XmlWriter.Create(sb, settings);

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize( xmlWriter, dtoArray, xmlSerializerNamespaces);
            return sb.ToString();
        }
    }
}
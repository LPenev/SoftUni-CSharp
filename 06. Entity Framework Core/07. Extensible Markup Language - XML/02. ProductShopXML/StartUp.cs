using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
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
            importFile = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportProducts(db, importFile));
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
    }
}
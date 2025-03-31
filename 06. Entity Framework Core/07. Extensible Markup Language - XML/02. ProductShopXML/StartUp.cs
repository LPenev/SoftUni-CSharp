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

            // 01. Import Users
            string importFile = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(db, importFile));
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

    }
}
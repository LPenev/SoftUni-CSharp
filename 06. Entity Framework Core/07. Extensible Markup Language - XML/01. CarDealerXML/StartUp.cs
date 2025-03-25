using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var inputXml = String.Empty;
            var output = String.Empty;

            // 09. Import Suppliers
            inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            output = ImportSuppliers(db, inputXml);



            // Print output
            Console.WriteLine(output);
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(importSuppliersDto[]), new XmlRootAttribute("Suppliers"));

            importSuppliersDto[] suppliersDto;

            using (var reader = new StringReader(inputXml)) 
            {
                suppliersDto = (importSuppliersDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = suppliersDto.Select(dto => new Supplier() 
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter
            }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            
            return $"Successfully imported {suppliers.Count()}";
        }

    }
}
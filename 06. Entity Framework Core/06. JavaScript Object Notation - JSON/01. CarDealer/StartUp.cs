using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace CarDealer
{
    //Microsoft.EntityFrameworkCore.Tools
    //Add-Migration Initial
    //Update-Database
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();

            // 09. Import Suppliers
            //var suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, suppliers));

            // 10. Import Parts
            var parts = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(db, parts));

        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var validSupplierIds = context.Suppliers.Select(x => x.Id);

            var partsWithValidSuppliers = parts.Where(x => validSupplierIds.Contains(x.SupplierId));

            context.AddRange(partsWithValidSuppliers);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
    }
}
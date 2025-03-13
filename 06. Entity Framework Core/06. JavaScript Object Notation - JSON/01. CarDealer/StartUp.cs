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
            //var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, suppliersJson));

            // 10. Import Parts
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(db, partsJson));

            // 11. Import Cars
            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(db, carsJson));



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

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

    }
}
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
            var suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(db, suppliers));


        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }


    }
}